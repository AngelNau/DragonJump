using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{


    public checkCollider jumpChecker;

    public Rigidbody2D player;
    public float moveSpeed = 5;
    public KeyCode[] movementArray = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    public int[] keyIndexes = {0, 1, 2, 3};
    public int axisRand = 1;
    float timer = 30;
    int direction = 0;

    bool releasedSwitch = false;
    
    public bool timerStarted = false;
    public bool isColliding = false;
    public float timerPlatform = 0f;
    public float timerDuration = 1.3f;

    bool sleep = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(movementArray[keyIndexes[0]])) {
            jump();
        } else if (Input.GetKeyDown(movementArray[keyIndexes[1]])) {
            down();
        }
        if (Input.GetKeyDown(movementArray[keyIndexes[2]])) {
            direction = -1;
        } else if (Input.GetKeyDown(movementArray[keyIndexes[3]])) {
            direction = 1;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[2]])) {
            direction = 0;
            releasedSwitch = true;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[3]])) {
            direction = 0;
            releasedSwitch = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && releasedSwitch) {
            timer = 5;
            //releasedSwitch = false;
            keyIndexes = generateRandomIx(4);
            for (int i = 0; i < 4; i++) {
                Debug.Log("ix:");
                Debug.Log(keyIndexes[i]);
            }
            
           
        }
        releasedSwitch = false;
        

        //bool isColliding = false;
        //bool timerStarted = false;
        //float timerDuration = 3f;
        //float timerPlatform = 0f;

        isColliding = jumpChecker.onPlatform;

        if (isColliding && !timerStarted)
        {
            Debug.Log("Start Timer");
            // Start the timer
            timerStarted = true;
            timerPlatform = 0f;
        }

        if (timerStarted)
        {
            // Increment the timer
            Debug.Log("timer: ");
            Debug.Log(timerPlatform);
            timerPlatform += Time.deltaTime;

            if (timerPlatform >= timerDuration)
            {
                // Timer expired, perform the action
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
                Debug.Log("Vreme je izteklo");
                // Reset the timer
                timerStarted = false;
                timerPlatform = 0f;
                player.WakeUp();
                sleep = false;
            }
        }

        if (isColliding) {
            if (!sleep) {
                sleep = true;
                player.Sleep();
            }
        }

        if (!isColliding) {
            sleep = false;
            timerStarted = false;
        }
        
        moveHorizontal(direction);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

    }

    void jump() {
        if(jumpChecker.canJump){
            player.velocity = Vector2.up * 5;

        }
    }

    void down() {
        if (player.velocity.y == 0 && transform.position.y >= 3.50f) {
                player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.7f);
            }
    }

    void moveHorizontal(int dir) {
        player.velocity = new Vector2(dir * moveSpeed, player.velocity.y);
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