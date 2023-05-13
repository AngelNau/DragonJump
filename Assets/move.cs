using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public float moveSpeed = 5f;

    void Update()
    {
        // Horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0f, 0f);
    }
}