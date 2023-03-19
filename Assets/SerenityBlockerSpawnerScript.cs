using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerenityBlockerSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spawner; 

    [SerializeField]
    private GameObject blockerPrefab;

    [SerializeField]
    private List<GameObject> blockers;

    [SerializeField]
    private float maxTimeBetweenSpawns;
    [SerializeField]
    private float minTimeBetweenSpawns;
    [SerializeField]
    private int concurrentBlockers;

    private float timer;

    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimeBetweenSpawns;
        blockers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (blockers.Count < concurrentBlockers && !waiting){
            timer = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            waiting = true;
        }

        if (timer <= 0 && waiting){

            Debug.Log("Spawning!");
            blockers.Add(Instantiate(blockerPrefab, spawner.transform.position, Quaternion.identity));
            waiting = false;

        }

        timer -= Time.deltaTime;
    }

    public void Kill(GameObject newGameObject){

        blockers.Remove(newGameObject);
        Destroy(newGameObject);

    }
}
