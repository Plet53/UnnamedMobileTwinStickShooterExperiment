using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
  public int hp, radius;
  public float newangle;
  public Vector3 center;
  public Vector2 move;
  public void OnTriggerEnter2D(Collider2D a) {
    Destroy(a.gameObject);
    hp--;
    if (hp < 1) Destroy(this.gameObject);
  }
  public void Start() {
    center = this.transform.position;
    move = Random.insideUnitCircle;
    move.Normalize();
    GetComponent<Rigidbody2D>().velocity = move * 20;
    StartCoroutine(MillAbout());
  }
  public IEnumerator MillAbout() {
    WaitForSeconds w1 = new WaitForSeconds(.5f);
    WaitUntil w2 = new WaitUntil(
      () =>  Vector3.Distance(this.transform.position, center) > radius);
    while (true) {
      yield return w2;
      GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      yield return w1;
      newangle = Random.value * (60 * Mathf.Deg2Rad) - (30 * Mathf.Deg2Rad);
      move *= -1;
      move.y -= Mathf.Sin(newangle); move.x -= (1 - Mathf.Cos(newangle));
      move.Normalize();
      GetComponent<Rigidbody2D>().velocity = move * 20;
      this.transform.rotation = Quaternion.Euler(0,0,Vector2.SignedAngle(Vector2.right, move));
      yield return w1;
    }
  }
}
