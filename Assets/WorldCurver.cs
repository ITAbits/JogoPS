using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	public Vector2 curveStrength;
	public Vector2 seed;

	public float speed = 1.0f;
	
	public float scale = 0.02f;

    int m_CurveStrengthID;

    private void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
    }

	void Update()
	{
		curveStrength = new Vector2(
			Mathf.PerlinNoise(speed * Time.time, seed.x) * scale,
			Mathf.PerlinNoise(speed * Time.time, seed.y) * scale
		);
		
		Shader.SetGlobalVector(m_CurveStrengthID, curveStrength);
	}
}
