/*************************************************************
 * Class Description:
 *      - Update the GUI of live in gameplay scene.
 *      - This class should be attached to LivesText object.
 *************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour {

    public static int lives;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        lives = 10;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Lives: " + lives;
    }
}
