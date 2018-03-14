using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{

  public Move move;
  public WorldCurver wc;

  // Use this for initialization
  void Start()
  {
    move.enabled = false;
    wc.enabled = false;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButton("Fire1"))
    {
      wc.initialTime = Time.time;
      move.enabled = true;
      wc.enabled = true;
    }
  }
}
