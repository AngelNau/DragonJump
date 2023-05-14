using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Transform platformTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = (playerTransform.position.y + platformTransform.position.y) / 2;
        //transform.position = newPos;
        if (newPos.y > 0) {
            transform.position = newPos;
        }
    }
}