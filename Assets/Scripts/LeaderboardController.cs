/*************************************************************
 * Class Description:
 *      - The main controller for leaderboard scene.
 *      - This class should be attached to knife object.
 *************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour {

	void Start () {
        //Update the GUI
        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.GetString("HScoreName" + i) == "")
            {
                GameObject.Find("txt_name" + i).GetComponent<Text>().text = "-";
            }
            else
            {
                GameObject.Find("txt_name" + i).GetComponent<Text>().text = PlayerPrefs.GetString("HScoreName" + i);
            }
            GameObject.Find("txt_level" + i).GetComponent<Text>().text = PlayerPrefs.GetInt("HScoreLevel" + i).ToString();
            GameObject.Find("txt_accuracy" + i).GetComponent<Text>().text = PlayerPrefs.GetFloat("HScoreAcc" + i).ToString();
        }
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
