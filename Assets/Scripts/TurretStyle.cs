using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;

public class TurretStyle : Player {
  public bool m;
  void Start() {
    r = 90; m = true;
    touch1 = Vector2.zero; touch2 = Vector2.zero; angle = Vector2.zero;
    s = false;
    StartCoroutine(CoolDown());
  }
  void Update() {
    if(Input.touchCount > 0) {
      Touch t = Input.touches[0];
      if (m) Move(t);
      else {
        Aim(t);
        if(!s) Shoot();
      }
      if (t.phase == TouchPhase.Ended) m = !m;
    }
  }
}
