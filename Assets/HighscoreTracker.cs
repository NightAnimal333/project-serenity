using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HighscoreTracker : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = "Highscore:\n" + Highscore.currentHighscore.ToString();
    }
}
