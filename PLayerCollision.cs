using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerCollision : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision){
    if(collision.transform.tag == "TEREN"){
       GameManager.isGameOver = true;
       gameObject.SetActive(false);
    }
   }
}
