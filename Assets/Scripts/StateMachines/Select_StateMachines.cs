using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Select_StateMachines : StateMachineBehaviour 
{
    [SerializeField]float value, animTime;
    
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<MeshRenderer>().material.SetFloat("_Intensity", 2);
        animator.GetComponent<AudioSource>().Play();        
    
    }
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
              
    // }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<MeshRenderer>().material.SetFloat("_Intensity", 0);        
    
    }
}
