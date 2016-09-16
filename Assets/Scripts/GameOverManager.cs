/*************************************************************
 * Class Description:
 *      - This class should be attached to Canvas object.
 *************************************************************/

using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //Check if the player's lives already reach 0 and the game hasnt over.
        if (LivesManager.lives <= 0 && !GameController.control.gameOver)
        {
            anim.SetTrigger("GameOver");
            GameController.control.gameOver = true;
            StartCoroutine(GameController.control.updateHighScores());
        }
    }
}