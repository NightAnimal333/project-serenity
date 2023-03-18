using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectsPerSide : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playerTransform;
    public bool isRightSide;

    private MeshRenderer mesh;
    private Material matt;

    private float lightness;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        matt = mesh.material;

        playerTransform = GameObject.Find("Player").transform;

        if ((playerTransform.position.x > 5f) == isRightSide)
            lightness = 0f;
        else
            lightness = 1f;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.x > 5f) == isRightSide)
            lightness = Mathf.Lerp(lightness, 0f, 6f * Time.deltaTime);
        else
            lightness = Mathf.Lerp(lightness, 1f, 6f * Time.deltaTime);

        matt.SetFloat("_Color", lightness);
    }
}
