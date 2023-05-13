using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platrofmMovement : MonoBehaviour
{
    public Rigidbody2D platform;
    public float moveSpeed = 5;
    public KeyCode[] movementArray = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public int[] keyIndexes = {0, 1, 2, 3};
    public int axisRand = 1;
    float timer = 5;
    int horizontalDir = 0;
    int verticalDir = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(movementArray[keyIndexes[0]])) {
                verticalDir = 1;
            } else if (Input.GetKeyDown(movementArray[keyIndexes[1]])) {
                verticalDir = -1;
            } else if (Input.GetKeyUp(movementArray[keyIndexes[0]])) {
                verticalDir = 0;
            } else if (Input.GetKeyUp(movementArray[keyIndexes[1]])) {
                verticalDir = 0;
            }
        if (Input.GetKeyDown(movementArray[keyIndexes[2]])) {
            horizontalDir = -1;
        } else if (Input.GetKeyDown(movementArray[keyIndexes[3]])) {
            horizontalDir = 1;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[2]])) {
            horizontalDir = 0;
            //releasedSwitch = true;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[3]])) {
            horizontalDir = 0;
            //releasedSwitch = true;
        }

        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 5;
            //releasedSwitch = false;
            keyIndexes = generateRandomIx(4);
            for (int i = 0; i < 4; i++) {
                Debug.Log("ix:");
                Debug.Log(keyIndexes[i]);
            }    
        }

        moveHorizontal(horizontalDir);
        moveVertical(verticalDir);
    }

    void moveHorizontal(int dir) {
        platform.velocity = new Vector2(dir * moveSpeed, platform.velocity.y);
    }

    void moveVertical(int dir) {
        platform.velocity = new Vector2(platform.velocity.x, dir * moveSpeed);
    }

    public static int[] generateRandomIx(int count)
    {

        List<int> numbers = new List<int>() { 0, 1, 2, 3 };
        int[] result = new int[count];

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, numbers.Count);
            result[i] = numbers[randomIndex];
            numbers.RemoveAt(randomIndex);
        }

        return result;
    }
}

