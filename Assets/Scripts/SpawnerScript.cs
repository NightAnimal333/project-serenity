using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spawner; 

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float timeBetweenSpawns;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawns){

            timer = 0;

            // Some trickery to make the obstacles spawn more frequently closer to the divide line.
            float temp = Random.Range(0f, 10f);
            float randomXCoordinate;
            if (temp > 6.5f){
                randomXCoordinate = (Random.Range(-5f, 2f));
            } else {
                randomXCoordinate = (Random.Range(2f, 5f));
            }

            Instantiate(obstacle, new Vector3(randomXCoordinate, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);

        }
    }
}
