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
<<<<<<< HEAD
    float timer = 30;
=======
    float timer = 5;
>>>>>>> b0bfe71 (Movement code, still contains small bug)
    int direction = 0;
    

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
<<<<<<< HEAD
        }
        if (Input.GetKeyDown(movementArray[keyIndexes[2]])) {
            direction = -1;
        } else if (Input.GetKeyDown(movementArray[keyIndexes[3]])) {
            direction = 1;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[2]])) {
            direction = 0;
            //releasedSwitch = true;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[3]])) {
            direction = 0;
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
        //releasedSwitch = false;
        

        
        moveHorizontal(direction);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

=======
        }
        if (Input.GetKeyDown(movementArray[keyIndexes[2]])) {
            direction = -1;
        } else if (Input.GetKeyDown(movementArray[keyIndexes[3]])) {
            direction = 1;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[2]])) {
            direction = 0;
            //releasedSwitch = true;
        } else if (Input.GetKeyUp(movementArray[keyIndexes[3]])) {
            direction = 0;
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
        //releasedSwitch = false;
        

        
        moveHorizontal(direction);


    }

    void jump() {
        if (player.velocity.y == 0) {
                player.velocity = Vector2.up * 5;
            }
    }

    void down() {
        if (player.velocity.y == 0) {
                player.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
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
>>>>>>> b0bfe71 (Movement code, still contains small bug)
    }

    void jump() {
        if(jumpChecker.canJump){
            player.velocity = Vector2.up * 5;

        }

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.16f);
        // if (hit.collider && hit.collider.name != "GameObject") {

        //     Debug.Log(hit.collider.name);
        //     Debug.Log("hits");
        //     player.velocity = Vector2.up * 5;
        // }
    }

    void down() {
        if (player.velocity.y == 0) {
                player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.6f);
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
