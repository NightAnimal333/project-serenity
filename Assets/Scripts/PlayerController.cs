using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SPEED;

    [SerializeField]
    private float MAX_HEALTH;
    [SerializeField]
    private float DAMAGE_ON_HIT;
    [SerializeField]
    private float HEALING_SPEED;

    [SerializeField]
    private float DRAG_MODIFIER;
    [SerializeField]
    private float ACCELERATION_MODIFIER;

    [SerializeField]
    private float health = 100;

    [SerializeField]
    private float MAX_VELOCITY = 1000;


    private bool healing = false;

    private bool blocked = false;
    private bool keyPressed = false;
    private bool dragging = false;

    [SerializeField]
    private bool lerping = false;

    [SerializeField]
    private float slerpTimer = 0f;

    private Vector3 velocity;
    private Vector3 targetVelocity;

    // private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
        targetVelocity = new Vector3(0, 0, 0);
        // rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blocked){

            // Basic input checks
            if (Input.GetKey(KeyCode.D) && targetVelocity.x < MAX_VELOCITY)
            { 
                targetVelocity.x += 5;
                keyPressed = true;
                lerping = true;
            }
            else if ((Input.GetKey(KeyCode.A)) && targetVelocity.x > -MAX_VELOCITY)
            {
                targetVelocity.x -= 5;
                keyPressed = true;
                lerping = true;
            } else 
            {
                keyPressed = false;
            }

            bool leftPressed = Input.GetKeyDown(KeyCode.A);
            bool rightPressed = Input.GetKeyDown(KeyCode.D);

            if (leftPressed || rightPressed){
                if (!(leftPressed && velocity.x < 0) && !(rightPressed && velocity.x > 0)){
                    velocity = velocity / 2;
                }
                targetVelocity = new Vector3(0, 0, 0);
                slerpTimer = 0;                
            }

            if (slerpTimer > 1 && !keyPressed){
                slerpTimer = 0;
                lerping = false;
            }

            // if (!keyPressed){
            //     targetVelocity = new Vector3(0, 0, 0);
            //     slerpTimer = 0f;
            //     lerping = true;
            // }

            // // dragging = false;
            // if (!lerping && !keyPressed && velocity.magnitude > 0.5f){
            //     targetVelocity = new Vector3(0, 0, 0);
            //     slerpTimer = 0f;
            //     lerping = true;
            //     // dragging = true;
            // }

            if (lerping){
                velocity = Vector3.Lerp(velocity, targetVelocity, slerpTimer);
                slerpTimer += ACCELERATION_MODIFIER * Time.deltaTime;
            }


        } else {
            velocity = new Vector3(-MAX_VELOCITY, 0, 0);
        }

        // if (!dragging){
        //     transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED;
        // } else {
        //     transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED / DRAG_MODIFIER;
        // }

        transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED;

        if (health <= 0){
            Destroy(this.gameObject);
        }

        if (healing){
            health += 1f * Time.deltaTime;
        }



    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("TriggerEnter");
        if (collider.gameObject.tag == "Obstacle"){
            // Debug.Log("Hit an obstacle!");
            health -= DAMAGE_ON_HIT;
        }
        else if (collider.gameObject.tag == "Serenity"){
            // Debug.Log("I'm in serenity");
            healing = true;
        } else if (collider.gameObject.tag == "Border"){
            targetVelocity = -velocity;
            velocity = new Vector3(0,0,0);
        }
        if (collider.gameObject.tag == "SerenityBlocker"){
            blocked = true;
        }

    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("TriggerExit");
        if (collider.gameObject.tag == "Serenity"){
            // Debug.Log("I'm in noise");
            healing = false;
        }
        if (collider.gameObject.tag == "SerenityBlocker"){
            blocked = false;
            lerping = false;
        }

    }
}
