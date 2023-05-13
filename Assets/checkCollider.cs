using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollider : MonoBehaviour
{
public  bool canJump = true;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer ==LayerMask.NameToLayer("Ground")){
            Debug.Log("Enter");
        canJump=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.layer ==LayerMask.NameToLayer("Ground")){
            Debug.Log("Exit");
        canJump =false; 
        }
    }
}
