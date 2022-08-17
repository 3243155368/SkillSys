using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBehaviour : MonoBehaviour
{
    private Animator animator;

    public Action attackHandler;

    private bool isPlay = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlaySkillAnim(string animName)
    {
        animator.Play(animName,-1,0);
        isPlay = true;
    }

    private void Update()
    {
        if(animator!=null && attackHandler!=null&&isPlay)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                attackHandler();
                isPlay = false;
            }
        }
    }
}
