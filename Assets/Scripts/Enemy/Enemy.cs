/*************************************************************
 * Class Description:
 *      - Base class for enemies object.
 *************************************************************/

using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    protected Animator myAnimator;
    protected Collider2D myCollider;

    [SerializeField]
    protected float movementSpeed;

    [SerializeField]
    protected int health;

    public abstract bool IsDead {get;}

	public virtual void Start () {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
	}
	
    public abstract void TakeDamage();

    public void setMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public IEnumerator Die()
    {
        myCollider.enabled = false;

        myAnimator.SetTrigger("die");

        GameController.control.killCount++;
        
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        if (!IsDead)
        {
            LivesManager.lives--;
            GameController.control.killCount++;
            Destroy(gameObject);
        }
    }
}
