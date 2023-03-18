using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SPEED;

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
    }
}