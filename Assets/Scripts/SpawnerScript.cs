using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawners; 

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

            int randomSpawner = Random.Range(0, spawners.Count);
            timer = 0;

            Instantiate(obstacle, spawners[randomSpawner].transform.position, Quaternion.identity);

        }
    }
}
