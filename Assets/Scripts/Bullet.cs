/*************************************************************
 * Class Description:
 *      - This class should be attached to bullet object.
 *************************************************************/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    //Movement speed of bullet
    private float speed;
    
    private Rigidbody2D myRigidBody;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        speed = 23;
	} 

    void FixedUpdate()
    {
        //Move bullet to the left
        myRigidBody.velocity = Vector2.left * speed;
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //If knife element type is superior compare to bullet element type, destroy bullet.
        if (gameObject.tag == "Bullet_Fire")
        {
            if (other.tag == "Knife_Water")
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Bullet_Earth")
        {
            if (other.tag == "Knife_Fire")
            {
                Destroy(gameObject);
            }
        } 
        else if (gameObject.tag == "Bullet_Thunder")
        {
            if (other.tag == "Knife_Earth")
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Bullet_Water")
        {
            if (other.tag == "Knife_Thunder")
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Bullet_Light")
        {
            if (other.tag == "Knife_Dark")
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Bullet_Dark")
        {
            if (other.tag == "Knife_Light")
            {
                Destroy(gameObject);
            }
        }
    }
}
