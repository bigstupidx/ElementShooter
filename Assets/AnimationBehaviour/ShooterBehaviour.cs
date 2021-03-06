﻿using UnityEngine;
using System.Collections;

public class ShooterBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Shooter[] s = GameObject.FindObjectsOfType<Shooter>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].isShooting == true)
            {
                s[i].Shoot(Random.Range(0, 6));
            }
        }
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("shoot");

        Shooter[] s = GameObject.FindObjectsOfType<Shooter>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].isShooting == true)
            {
                s[i].isShooting = false;
            }
        }
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
