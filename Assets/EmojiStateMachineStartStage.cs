using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiStateMachineStartStage : StateMachineBehaviour
{
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<MonoBehaviour>().StartCoroutine(WaitToDestroy(animator));
    }
    IEnumerator WaitToDestroy(Animator animator){
        yield return new WaitForSeconds(.2f);
        animator.SetBool("enable",true);
    }
}
