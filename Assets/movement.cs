using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{


    public checkCollider jumpChecker;

    public Rigidbody2D player;
    public float moveSpeed = 5;
    public KeyCode[] movementArray = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    public KeyCode[] movementWASD = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public KeyCode[] current = new KeyCode[4];
    public int[] keyIndexes = {0, 1, 2, 3};
    public int axisRand = 1;
    public AudioSource audio;
    float timer = 40f;
    int direction = 0;
    float jumpTimer = 10f;

    //bool releasedSwitch = false;
    
    public bool timerStarted = false;
    public bool isColliding = false;
    public float timerPlatform = 0f;
    public float timerDuration = 1f;
    public Animator animatorDragon;
    public float runSpeed = 40f;
    float horizontalMoveA = 0f;

    public float switchPlayerTimer = 26f;
    public int currentIx = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        for (int i = 0; i < 4; i++) {
            current[i] = movementArray[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMoveA = Input.GetAxisRaw("Horizontal") * runSpeed;
        animatorDragon.SetFloat("Speed", Mathf.Abs(horizontalMoveA));

        if (Input.GetKeyDown(current[keyIndexes[0]])) {animatorDragon.SetBool("isJumping", true);
            player.drag = 0;
            animatorDragon.SetBool("isJumping", true);
            jump();
            animatorDragon.SetBool("isJumping", false);
        } else if (Input.GetKeyDown(current[keyIndexes[1]])) {
            down();
        }
        if (Input.GetKeyDown(current[keyIndexes[2]])) {
            //player.drag = 0;
            direction = -1;
            play();
        } else if (Input.GetKeyDown(current[keyIndexes[3]])) {
            //player.drag = 0;
            direction = 1;
        } else if (Input.GetKeyUp(current[keyIndexes[2]])) {
            direction = 0;
            stopAudio();
            //releasedSwitch = true;
        } else if (Input.GetKeyUp(current[keyIndexes[3]])) {
            direction = 0;
            //releasedSwitch = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 5;
            //releasedSwitch = false;
            keyIndexes = generateRandomIx(4);
        }
        
        

        //bool isColliding = false;
        //bool timerStarted = false;
        //float timerDuration = 3f;
        //float timerPlatform = 0f;

        isColliding = jumpChecker.onPlatform;

        if (isColliding && !timerStarted)
        {
            // Start the timer
            timerStarted = true;
            timerPlatform = 0f;
        }

        if (timerStarted)
        {
            // Increment the timer
            //Debug.Log("timer: ");
            //Debug.Log(timerPlatform);
            timerPlatform += Time.deltaTime;


            if (timerPlatform >= timerDuration)
            {
                // Timer expired, perform the action
                
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
                // Reset the timer
                timerStarted = false;
                timerPlatform = 0f;
            }
        }

        if (isColliding) {
            player.drag = 1000;
        }

        if (!isColliding) {
            timerStarted = false;
            player.drag = 0;
        }

        if (!jumpChecker.canJump) {
            animatorDragon.SetFloat("Speed", 0);
        }

        switchPlayerTimer -= Time.deltaTime;
        /*
        if (releasedSwitch) {
            if (switchPlayerTimer <= 0) {
                if (currentIx == 0) {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementWASD[i];
                    }
                    currentIx = 1;
                } else {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArray[i];
                    }
                    currentIx = 0;
                }
                switchPlayerTimer = 10f;
            }
        }
        */
        
        if (switchPlayerTimer <= 0) {
                if (currentIx == 0) {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementWASD[i];
                    }
                    currentIx = 1;
                } else {
                    for (int i = 0; i < 4; i++) {
                        current[i] = movementArray[i];
                    }
                    currentIx = 0;
                }
                switchPlayerTimer = 10f;
            }
        //releasedSwitch = false;

        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0) {
            jumpChecker.canJump = true;
            jumpTimer = 10f;
        }
        
        moveHorizontal(direction);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

        if (jumpChecker.levelFinished) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 2);
            jumpChecker.levelFinished = false;
        }

    }

    void jump() {
        if(jumpChecker.canJump){
            // animatorDragon.SetBool("isJumping", true);
            player.velocity = Vector2.up * 5;
            // Invoke("ResetJump", 0.2f);
        }
    }

    void ResetJump() {
        player.drag = 0;
        animatorDragon.SetBool("isJumping", false);
    }

    void down() {
        if (player.velocity.y == 0 && transform.position.y >= 3.50f) {
            player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.7f);
        }
    }

    void moveHorizontal(int dir) {
        player.drag = 0;
        player.velocity = new Vector2(dir * moveSpeed, player.velocity.y);
    }

    void play() {
        audio.time = 5f;
        audio.Play();
    }

    void stopAudio() {
        audio.Stop();
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