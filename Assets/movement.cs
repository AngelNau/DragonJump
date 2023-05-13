using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{



    public Rigidbody2D player;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(moveInput * moveSpeed, player.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (player.velocity.y == 0) {
                player.velocity = Vector2.up * 5;
            }
        }
    }
}
