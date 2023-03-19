using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI scoreText;

    float scoreCounter = 0;
    float playerHealth = 0;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerController.health;
        scoreCounter += Time.deltaTime;
        Highscore.SetHighscore((int)scoreCounter + 1);
        scoreText.text = "Time alive:\n<u>" + ((int) scoreCounter + 1).ToString() + " seconds</u>\n\nIntegrity: " + ((int) playerHealth).ToString();
        
    }
}
