using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prsten : MonoBehaviour
{
 private int poen = 0;
public TextMeshProUGUI poeni;
public TextMeshProUGUI UkupanBrojPoena;
 private void OnTriggerEnter(Collider other){
    if(other.transform.tag == "poencic"){
        poen ++;
        poeni.text = "Poen: " + poen.ToString();
        UkupanBrojPoena.text = "Ukupan broj poena: " + poen.ToString();
        Destroy(other.gameObject);
    }

 }

}
