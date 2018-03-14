Shader "GUI/Curved 3D Text Shader - Cull Back" {
	Properties {
		_MainTex ("Font Texture", 2D) = "white" {}
		_Color ("Text Color", Color) = (1,1,1,1)
	}
 
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Lighting Off Cull Off ZWrite Off Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment fragment
			// make fog work 
			#pragma multi_compile_fog
				
			#include "CurvedCode.cginc"

			fixed4 _Color;
			fixed4 fragment(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col;
				col.rgb = _Color.rgb * (1-tex2D(_MainTex, i.uv).rgb);
				col.a = tex2D(_MainTex, i.uv).a;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}

			ENDCG
		}
		
	}
}