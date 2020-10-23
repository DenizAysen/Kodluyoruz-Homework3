using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    

    public void JumpAnimation()
    {
        animator.SetTrigger("isJump");
    }
}
