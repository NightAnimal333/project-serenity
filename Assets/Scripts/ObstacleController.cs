using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float accelerationModifier;

    // Start is called before the first frame update
    void Start()
    {
        speed += accelerationModifier * Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (new Vector3(0, 0, -1)) * speed * Time.deltaTime;

        if (transform.position.z <= -30f){
            Destroy(this.gameObject);
        }

        
    }
}
