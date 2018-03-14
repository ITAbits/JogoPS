Shader "Unlit/NewCurvedUnlit"
{ 
	Properties
	{
		//Main
		_MainTex ("Texture", 2D) = "white" {}
		_Tint("Holo Tint", color) = (1., 0, 0, 1.)
		_Alpha("Transparency", Range(0, 1)) = 0.2
		_Brightness("Brightness", Range(0.1, 6.0)) = 3.0

		//Fresnel
		_FresnelColor("Fresnel Color", Color) = (1,1,1,1)
		_FresnelPower("Fresnel Power", Range(0.1, 10)) = 5.0
	}
	SubShader
	{
			Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			LOD 100
			ColorMask RGB
			ZWrite Off
			Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work 
			#pragma multi_compile_fog
				
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 color : TEXCOORD2;
				float4 vertex : SV_POSITION;
				float4 worldPos : TEXCOORD3;
				float3 worldNormal : TEXCOORD4;
				float3 viewDir : TEXCOORD5;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _Tint;
			float _Alpha;
			fixed4 _FresnelColor;
			float _FresnelPower;
			float _Brightness;
			float2 _CurveStrength;


			v2f vert(appdata v)
			{
				v2f o;

				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos.xyz));

				float _Horizon = 100.0f;
				float _FadeDist = 50.0f;

				o.vertex = UnityObjectToClipPos(v.vertex);


				float dist = UNITY_Z_0_FAR_FROM_CLIPSPACE(o.vertex.z);

				o.vertex.x -= _CurveStrength.x * dist * dist * _ProjectionParams.x;
				o.vertex.y -= _CurveStrength.y * dist * dist * _ProjectionParams.x;

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.color = v.color;

				UNITY_TRANSFER_FOG(o, o.vertex);
				return o;
			}

			float4 HorizontalBars(float y)
			{
				return 1. - saturate(round(abs(frac(y * 0.2) * (7 + 0.7 * sin(_Time.y)))));
			}

			fixed4 frag(v2f i) : SV_Target
			{
				//Tex
				fixed4 texColor = tex2D(_MainTex, i.uv);
				float transparency = _Alpha + 0.15 * sin(_Time.y);

				//Fresnel
				float fresnel = 1. - saturate(dot(i.viewDir, i.worldNormal));
				fixed4 fresnelColor = _FresnelColor * pow(fresnel, _FresnelPower);


				//Color
				fixed4 col = _Tint * texColor + fresnelColor;

				col.a = texColor.a * transparency * fresnelColor + HorizontalBars(i.worldPos.z) + HorizontalBars(i.worldPos.z + 0.6);

				col.rgb = col.rgb * (_Brightness + 1.6 * sin(_Time.y));

				//col = (1 - dissolve / 0.05)* _Tint + dissolve / 0.05 * col;

				//col.a = col.a * max(sign(_CutOff - tex2D(_DissolveTex, i.uv).r), 0);

				return col;
			}

			ENDCG
		}
	}
}
