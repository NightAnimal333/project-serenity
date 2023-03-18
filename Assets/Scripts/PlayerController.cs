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
    private float health = 100;

    private bool healing = false;

    private bool blocked = false;
    private bool keyPressed = false;

    [SerializeField]
    private bool lerping = false;

    [SerializeField]
    private float slerpTimer = 0f;

    private Vector3 oldVelocity;
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

        if (Input.GetKey(KeyCode.D) && !blocked)
        { 
            targetVelocity.x += 5;
        }
        else if (Input.GetKey(KeyCode.A) || blocked)
        {
            targetVelocity.x -= 5;
        } else 
        {
            //targetVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){

            targetVelocity = new Vector3(0, 0, 0);
            slerpTimer = 0;

        }

        velocity = Vector3.Slerp(velocity, targetVelocity, slerpTimer);
        slerpTimer += Time.deltaTime;

        if (slerpTimer > 1){
            slerpTimer = 0;
        }

        transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED;



        // if (Input.GetKey(KeyCode.D))
        // {
            
        //     velocity.x += 5;
        //     lerping = true;
        //     keyPressed = true;
        //     // slerpTimer = .5f;

        // }

        // else if (Input.GetKey(KeyCode.A))
        // {
        //     velocity.x -= 5;
        //     lerping = true;
        //     keyPressed = true;
        //     // slerpTimer = .5f;

        // }
        // else
        // {
        //     keyPressed = false;
        // }

        // if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
        //     velocity = new Vector3 (0,0,0);
        //     oldVelocity = velocity;
        //     slerpTimer = 0;
        //     lerping = true;
        // }

        // if (lerping){
        //     // This means we only Lerp the X-axis
        //     velocity = new Vector3(Vector3.Slerp(oldVelocity, velocity, slerpTimer).x, velocity.y, velocity.z);
        //     slerpTimer += SPEED;
        // }

        // if (slerpTimer > 1 && !keyPressed){
        //     lerping = false;
        //     slerpTimer = 0;
        //     velocity = new Vector3(0,0,0);
                        
        // }

        // transform.position += velocity * Time.deltaTime;

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
        }

    }
}
