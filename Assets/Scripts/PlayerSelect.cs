using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;

public class PlayerSelect : MonoBehaviour
{
  public GameObject[] controls, textpile;
  public int c;
  public int control {get {return c;} set {c = value;}}
  public GameObject shot, player, menu, enemyset, enemies;
  public void EnterGame(){
    textpile[0].SetActive(false);
    try{player = Instantiate<GameObject>(controls[c], Vector3.zero, Quaternion.identity);
      enemies = Instantiate<GameObject>(enemyset, Vector3.zero, Quaternion.identity);
      menu.SetActive(false);
      textpile[1].SetActive(false);
      textpile[2].SetActive(false);
      textpile[3].SetActive(false);}
    catch(System.IndexOutOfRangeException){textpile[0].SetActive(true);}
  }
  public void ExitGame(){
    Destroy(player);
    Destroy(enemies);
    menu.SetActive(true);
  }
}
