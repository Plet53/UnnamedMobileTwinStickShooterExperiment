using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D a){
    Destroy(a.gameObject);
  }
}
