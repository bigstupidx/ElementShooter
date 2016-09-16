/*************************************************************
 * Class Description:
 *      - Update the GUI of level in gameplay scene.
 *      - This class should be attached to LevelText object.
 *************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static int level = 1;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
	}
	
	void Update () {
        text.text = "Level: " + level;
	}
}
