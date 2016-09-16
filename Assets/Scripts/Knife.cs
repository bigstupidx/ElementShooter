/*************************************************************
 * Class Description:
 *      - This class should be attached to knife object.
 *************************************************************/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour {

    //Movement speed of knife
    private float speed;

    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        speed = 30;
	} 

    void FixedUpdate()
    {
        //Move knife to the right
        myRigidBody.velocity = Vector2.right * speed;
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //If knife collide with enemy, update the hit counter and destroy knife.
        //If knife collide with bullet, destroy knife.
        switch (other.tag)
        {
            case "Enemy":
                GameController.control.totalHit++;
                Destroy(gameObject);
                break;
            case "Bullet_Fire":
            case "Bullet_Earth":
            case "Bullet_Thunder":
            case "Bullet_Water":
            case "Bullet_Light":
            case "Bullet_Dark":
                Destroy(gameObject);
                break;
        }
        
    }
}
