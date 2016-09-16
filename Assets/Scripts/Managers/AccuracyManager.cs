/*************************************************************
 * Class Description:
 *      - Update the GUI of accuracy in gameplay scene.
 *      - This class should be attached to AccuracyText object.
 *************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccuracyManager : MonoBehaviour {

    public static float accuracy;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        accuracy = 0;
    } 

    void Update()
    {
        if (GameController.control.totalHit <= 0)
        {
            text.text = "Acc: - %";
        }
        else
        {
            accuracy = (float)System.Math.Round((GameController.control.rightHit / GameController.control.totalHit) * 100, 2);
            text.text = "Acc: " + accuracy + " %";
        }
    }
}
