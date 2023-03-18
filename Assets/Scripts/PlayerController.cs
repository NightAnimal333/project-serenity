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
    private float health = 100;

    private bool healing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.D))
            {
                velocity.x += 1;
            }

        else if (Input.GetKey(KeyCode.A))
            {
                velocity.x -= 1;
            }

        transform.position += velocity * SPEED * Time.deltaTime;

        if (health <= 0f){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision detected");
        if (collider.gameObject.tag == "Obstacle"){
            Debug.Log("Hit an obstacle!");
            health -= DAMAGE_ON_HIT;
        }
        else if (collider.gameObject.tag == "Serenity"){
            Debug.Log("I'm in serenity");
        }

    }
}
