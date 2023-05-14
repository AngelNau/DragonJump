using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platrofmMovement : MonoBehaviour
{
    public checkCollider checkIfOnPlatform;
    public Camera m_MainCamera;
    public Rigidbody2D platform;
    public float moveSpeed = 5;
    public KeyCode[] movementArray = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public KeyCode[] movementArrows = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    private KeyCode[] current = new KeyCode[4];
    public int currentIx = 1;
    public int[] keyIndexes = {0, 1, 2, 3};
    public int axisRand = 1;
    float timer = 30;
    int horizontalDir = 0;
    int verticalDir = 0;

    public float switchPlayerTimer = 10f;
    //public bool releasedSwitch = false;

    void Start()
    {
        for (int i = 0; i < 4; i++) {
            current[i] = movementArray[i];
        }
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(current[keyIndexes[0]])) {
                verticalDir = 1;
            } else if (Input.GetKeyDown(current[keyIndexes[1]])) {
                verticalDir = -1;
            } else if (Input.GetKeyUp(current[keyIndexes[0]])) {
                verticalDir = 0;
            } else if (Input.GetKeyUp(current[keyIndexes[1]])) {
                verticalDir = 0;
            }
        if (Input.GetKeyDown(current[keyIndexes[2]])) {
            horizontalDir = -1;
        } else if (Input.GetKeyDown(current[keyIndexes[3]])) {
            horizontalDir = 1;
        } else if (Input.GetKeyUp(current[keyIndexes[2]])) {
            horizontalDir = 0;
            //releasedSwitch = true;
        } else if (Input.GetKeyUp(current[keyIndexes[3]])) {
            horizontalDir = 0;
            //releasedSwitch = true;
        }
        

        Vector2 stageDimensions = m_MainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 5;
            keyIndexes = generateRandomIx(4);
        }


        if(verticalDir != 1 && platform.position.y >= stageDimensions.y) {
            platform.position = new Vector2(platform.position.x, stageDimensions.y);
        }


        switchPlayerTimer -= Time.deltaTime;
        /*
        if (releasedSwitch) {
            if (switchPlayerTimer <= 0) {
                if (currentIx == 0) {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArray[i];
                    }
                    currentIx = 1;
                } else {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArrows[i];
                    }
                    currentIx = 0;
                }
                switchPlayerTimer = 10f;
            }
        }
        */
        //releasedSwitch = false;
    
        if (switchPlayerTimer <= 0) {
                if (currentIx == 0) {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArray[i];
                    }
                    currentIx = 1;
                } else {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArrows[i];
                    }
                    currentIx = 0;
                }
                switchPlayerTimer = 10f;
            }


        moveHorizontal(horizontalDir);
        moveVertical(verticalDir);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
    }

    float abs(float a, float b) {
        return (a - b) < 0 ? (a - b) * (-1) : (a - b);
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

