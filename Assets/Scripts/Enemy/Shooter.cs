/*************************************************************
 * Class Description:
 *      - This class should be attached to Shooter object.
 *************************************************************/

using UnityEngine;
using System.Collections;

public class Shooter : Enemy {

    private int type;
    public bool isShooting;

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    [SerializeField]
    private GameObject[] bulletPrefabs;

	public override void Start () {
        base.Start();

        movementSpeed = 2;
        health = 1;
        
        type = Random.Range(1, 7);
        myAnimator.SetInteger("Type", type);

        isShooting = false;
	}
	
	void FixedUpdate(){
        //Move only if not dead and not shooting
        if (!IsDead && !isShooting)
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
        //If got hit by the superior element, shooter's health decreased.
        //and rightHit counter increases for accuracy management.
        //If not, shooter shoot back random type bullet.
        if (type == 1)
        {
            switch (other.tag)
            {
                case "Knife_Water":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Fire":
                case "Knife_Earth":
                case "Knife_Thunder":
                case "Knife_Light":
                case "Knife_Dark":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
            }
            
        }
        else if (type == 2)
        {
            switch (other.tag)
            {
                case "Knife_Fire":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Water":
                case "Knife_Earth":
                case "Knife_Thunder":
                case "Knife_Light":
                case "Knife_Dark":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
            }
        }
        else if (type == 3)
        {
            switch (other.tag)
            {
                case "Knife_Earth":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Fire":
                case "Knife_Water":
                case "Knife_Thunder":
                case "Knife_Light":
                case "Knife_Dark":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
            }
        }
        else if (type == 4)
        {
            switch (other.tag)
            {
                case "Knife_Thunder":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Fire":
                case "Knife_Earth":
                case "Knife_Water":
                case "Knife_Light":
                case "Knife_Dark":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
            }
        }
        else if (type == 5)
        {
            switch (other.tag)
            {
                case "Knife_Dark":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Fire":
                case "Knife_Earth":
                case "Knife_Thunder":
                case "Knife_Light":
                case "Knife_Water":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
            }
        }
        else if (type == 6)
        {
            switch (other.tag)
            {
                case "Knife_Light":
                    TakeDamage();
                    GameController.control.rightHit++;
                    break;
                case "Knife_Fire":
                case "Knife_Earth":
                case "Knife_Thunder":
                case "Knife_Water":
                case "Knife_Dark":
                    myAnimator.SetTrigger("shoot");
                    isShooting = true;
                    break;
                default:
                    break;
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

    public void Shoot(int value)
    {
        Instantiate(bulletPrefabs[value], transform.position, transform.rotation);
    }
}
