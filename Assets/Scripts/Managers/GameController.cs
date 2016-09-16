/*************************************************************
 * Class Description:
 *      - The main controller for gameplay scene.
 *      - This class should be attached to GameController object.
 *************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static GameController control;

    public Player player;
    public Spawner spawner;

    public int killCount;
    public float rightHit;
    public float totalHit;
    public bool gameOver;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }


	void Start () {
        //Initiate first level
        spawner.Run(LevelManager.level);
	}
	
    void Update()
    {
        //Check if not yet game over
        if (!gameOver)
        {
            //Once level completed, do necessary stuff.
            if (killCount >= LevelManager.level)
            {
                LevelManager.level++;
                killCount = 0;
                spawner.Run(LevelManager.level);
            }
        }
    }

    public IEnumerator updateHighScores()
    {
        int newLevel, oldLevel;
        string newName, oldName;
        float newAcc, oldAcc;

        newName = "mcl";
        newLevel = LevelManager.level;
        newAcc = AccuracyManager.accuracy;

        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.HasKey("HScoreLevel" + i))
            {
                if (PlayerPrefs.GetInt("HScoreLevel" + i) < newLevel)
                {
                    //if new level is higher than the stored level
                    oldName = PlayerPrefs.GetString("HScoreName" + i);
                    oldLevel = PlayerPrefs.GetInt("HScoreLevel" + i);
                    oldAcc = PlayerPrefs.GetFloat("HScoreAcc" + i);

                    PlayerPrefs.SetString("HScoreName" + i, newName);
                    PlayerPrefs.SetInt("HScoreLevel" + i, newLevel);
                    PlayerPrefs.SetFloat("HScoreAcc" + i, newAcc);

                    newLevel = oldLevel;
                    newAcc = oldAcc;
                }
            }
            else
            {
                PlayerPrefs.SetString("HScoreName" + i, newName);
                PlayerPrefs.SetInt("HScoreLevel" + i, newLevel);
                PlayerPrefs.SetFloat("HScoreAcc" + i, newAcc);
                newName = "new";
                newLevel = 0;
                newAcc = 0;
            }
        }

        yield return new WaitForSeconds(0.6f);
    }
}
