/*************************************************************
 * Class Description:
 *      - The main controller for menu scene.
 *      - This class should be attached to MenuController object.
 *************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
