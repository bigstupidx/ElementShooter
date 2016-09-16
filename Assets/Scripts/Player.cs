/*************************************************************
 * Class Description:
 *      - The main controller for player behaviour.
 *      - This class should be attached to player object.
 *************************************************************/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int floor;
    private int knifeType;

    private Animator myAnimator;

    [SerializeField]
    private Transform[] spawnPoints;

    private static Player instance;

    public static Player Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance; 
        }
    }

    [SerializeField]
    private Transform knifePos;

    [SerializeField]
    private GameObject[] knifePrefabs;

    public bool Attack { get; set; }
	
	public void Start () {
        myAnimator = GetComponent<Animator>();

        //Set the starting floor
        floor = 1;
	}

	// Update is called once per frame
	void Update () 
    {
        HandleInput();
	}

    //Handle the keyboard input for gameplay
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (floor == 1)
            {
                transform.position = spawnPoints[0].position;
                floor = 2;
            }else if(floor == 2)
            {
                transform.position = spawnPoints[1].position;
                floor = 1;
            }
        }

        if(Input.GetKeyUp(KeyCode.Alpha1)){
            knifeType = 0;
            myAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            knifeType = 1;
            myAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            knifeType = 2;
            myAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            knifeType = 3;
            myAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            knifeType = 4;
            myAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            knifeType = 5;
            myAnimator.SetTrigger("throw");
        }
    }

    //Spawn a knife by instatiating it
    public void ThrowKnife(int value)
    {
        Instantiate(knifePrefabs[knifeType], transform.position, transform.rotation );
    }

    //Handle movement via button press
    public void BtnMove()
    {
        if (floor == 1)
        {
            transform.position = spawnPoints[0].position;
            floor = 2;
        }
        else if (floor == 2)
        {
            transform.position = spawnPoints[1].position;
            floor = 1;
        }
    }

    //Handle knife shooting via button press
    public void BtnFire()
    {
        knifeType = 0;
        myAnimator.SetTrigger("throw");
    }

    public void BtnEarth()
    {
        knifeType = 1;
        myAnimator.SetTrigger("throw");
    }

    public void BtnThunder()
    {
        knifeType = 2;
        myAnimator.SetTrigger("throw");
    }

    public void BtnWater()
    {
        knifeType = 3;
        myAnimator.SetTrigger("throw");
    }

    public void BtnLight()
    {
        knifeType = 4;
        myAnimator.SetTrigger("throw");
    }

    public void BtnDark()
    {
        knifeType = 5;
        myAnimator.SetTrigger("throw");
    }
}
