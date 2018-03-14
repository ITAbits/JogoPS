using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tunnel : MonoBehaviour
{

  // Use this for initialization
  public float seed = 0.0f;
  public float speed = 1.0f;
  void Start()
  {
		CreateInvertedMeshCollider();

  }
  public void CreateInvertedMeshCollider()
  {
    InvertMesh();
    gameObject.AddComponent<MeshCollider>();
    InvertMesh();
  }
  private void InvertMesh()
  {
    Mesh mesh = GetComponent<MeshFilter>().mesh;
    mesh.triangles = mesh.triangles.Reverse().ToArray();
  }
  // Update is called once per frame
  void Update()
  {
    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 360.0f * Mathf.PerlinNoise(seed, speed * Time.time));
  }
}
