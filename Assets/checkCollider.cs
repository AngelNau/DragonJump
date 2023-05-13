using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollider : MonoBehaviour
{
public  bool canJump = true;
public bool onPlatform = false;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
            Debug.Log("Enter");
            canJump=true;
        }
        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerPlatform")) {
            Debug.Log("On Platform");
            onPlatform = true;
            canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
            Debug.Log("Exit");
            canJump = false; 
        }
        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerPlatform")) {
            Debug.Log("Off Platform");
            onPlatform = false;
            canJump = false;
        }
    }
}
