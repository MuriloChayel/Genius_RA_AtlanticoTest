using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCenter : StateMachineBehaviour
{
      override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
      animator.GetComponent<MeshRenderer>().material.SetFloat("_Intensity",2);
      }
      override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
      animator.GetComponent<MeshRenderer>().material.SetFloat("_Intensity",0);
   }
}
