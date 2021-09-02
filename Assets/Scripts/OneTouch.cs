using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;
public class OneTouch : Player
{
  void Start()
  {
    r = 90;
    touch1 = Vector2.zero; touch2 = Vector2.zero; angle = Vector2.zero;
    s = false;
    StartCoroutine(CoolDown());
  }

  void Update()
  {
    if(Input.touchCount > 0){
      Touch t = Input.touches[0];
      if(t.phase == TouchPhase.Began){
        Move(t);
      }else{
        Aim(t);
        if(!s){
          Shoot();}}
    }
  }
}
