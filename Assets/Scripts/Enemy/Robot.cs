/*************************************************************
 * Class Description:
 *      - This class should be attached to Robot object.
 *************************************************************/

using UnityEngine;
using System.Collections;

public class Robot : Enemy {

    private int type;

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }
    
	public override void Start () {
        base.Start();

        movementSpeed = 2;
        health = 1;

        type = Random.Range(1, 7);

        myAnimator.SetInteger("Type", type);
	}
	
	void FixedUpdate(){
        if (!IsDead)
        {
            Move();
        }
	}

    public void Move()
    {
        //Movement is pre-fixed to go left
        transform.Translate(Vector2.left * (movementSpeed * Time.deltaTime));
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        //If got hit by the superior element, Robot's health decreased.
        //and rightHit counter increases for accuracy management.
        //If not, Robot element type will change randomly.
        if (type == 1)
        {
            if (other.tag == "Knife_Water")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 1);

                myAnimator.SetInteger("Type", type);
            }
        }
        else if (type == 2)
        {
            if (other.tag == "Knife_Fire")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 2);

                myAnimator.SetInteger("Type", type);
            }
        }
        else if (type == 3)
        {
            if (other.tag == "Knife_Earth")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 3);

                myAnimator.SetInteger("Type", type);
            }
        }
        else if (type == 4)
        {
            if (other.tag == "Knife_Thunder")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 4);

                myAnimator.SetInteger("Type", type);
            }
        }
        else if (type == 5)
        {
            if (other.tag == "Knife_Dark")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 5);

                myAnimator.SetInteger("Type", type);
            }
        }
        else if (type == 6)
        {
            if (other.tag == "Knife_Light")
            {
                TakeDamage();
                GameController.control.rightHit++;
            }
            else
            {
                do
                {
                    type = Random.Range(1, 7);
                } while (type == 6);

                myAnimator.SetInteger("Type", type);
            }
        }
    }

    public override void TakeDamage()
    {
        health--;

        if (IsDead)
        {
            StartCoroutine("Die");
        }
    }
}
