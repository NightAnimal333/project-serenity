using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerenityBlockerController : MonoBehaviour
{
    [SerializeField]
    private float SPEED;

    [SerializeField]
    private SerenityBlockerSpawnerScript blockerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        blockerSpawner = GameObject.Find("SerenityBlockerSpawnerHolder").GetComponent<SerenityBlockerSpawnerScript>();
        Debug.Log(blockerSpawner);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Random.Range(10, 30));
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (new Vector3(0, 0, -1)) * SPEED * Time.deltaTime;

        if (transform.position.z <= -50f){
            blockerSpawner.Kill(this.gameObject);
        }
        
    }
}
