using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    public void SetRunningAnimation(bool isRunning)
    {
        myAnim.SetBool("isRunning", isRunning);
    }

    public void TriggerKick()
    {
        myAnim.SetTrigger("triggerKick");
    }
}
