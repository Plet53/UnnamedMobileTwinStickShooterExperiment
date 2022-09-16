using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSS {
  public class Player : MonoBehaviour {
    public Vector2 touch1, touch2, angle;
    public float r;
    public GameObject shot;
    public bool s;
    public IEnumerator CoolDown() {
      WaitForSeconds w = new WaitForSeconds(.2f);
      WaitUntil cs = new WaitUntil(() => s);
      while(true) {
        yield return cs;
        yield return w;
        s = false;
      }
    }
    public void Move(Touch t) {
      touch1 = t.position;
      this.transform.position = touch1;
    }
    public void Aim(Touch t) {
      touch2 = t.position;
      angle = touch2 - touch1;
      angle.Normalize();
      r = Vector2.SignedAngle(Vector2.right, angle);
      if (t.phase == TouchPhase.Ended) r = 90;
      this.transform.rotation = Quaternion.Euler(0,0,r);
    }
    public void Shoot() {
      s = true;
      Vector3 pos = new Vector3(this.transform.position.x + angle.x, this.transform.position.y + angle.y, 0);
      GameObject bullet = Instantiate<GameObject>(shot, pos, Quaternion.Euler(0,0,r));
      bullet.GetComponent<Rigidbody2D>().velocity = (angle * 600);
    }
  }
}
