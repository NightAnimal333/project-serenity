using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Highscore
{
    // Start is called before the first frame update
    public static int currentHighscore = 0;

    public static void SetHighscore(int newHighscore)
    {

        if (currentHighscore < newHighscore)
        {

            currentHighscore = newHighscore;

        }

    }
}
