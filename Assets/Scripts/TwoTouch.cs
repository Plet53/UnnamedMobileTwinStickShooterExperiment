using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;

public class TwoTouch : Player
{
  public int t1, t2, lc;
  void Start(){
    t1 = 0; t2 = 1; lc = 0; r = 90;
    touch1 = Vector2.zero; touch2 = Vector2.zero; angle = Vector2.zero;
    s = false;
    StartCoroutine(CoolDown());
  }
  void Update()
  {
    int i = 0;
    Touch[] t = Input.touches;
    for(i = 0; i < Input.touchCount; i++){
      if(t1 == t[i].fingerId){
        Move(t[i]);
      }else if(t2 == t[i].fingerId){
        Aim(t[i]);
      }
    }
    if((lc == 2) && (i == 1) && (t[0].fingerId == t2)){
      int temp = t1;
      t1 = t2; t2 = temp;
    }
    if((lc == 1) && (i == 0)){
      t1 = 0; t2 = 1;
    }
    if(!s && i == 2){
      Shoot();
    }
    lc = i;
  }
}
