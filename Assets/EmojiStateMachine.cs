using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiStateMachine : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public float duration;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        duration = animator.GetComponentInParent<EmojiClass>().duration;
        animator.GetComponentInParent<MonoBehaviour>().StartCoroutine(WaitToDestroy(animator,duration));
    }
    IEnumerator WaitToDestroy(Animator animator,float duration){
        yield return new WaitForSeconds(duration);
        animator.SetBool("enable",false);
    }
}
