using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

   public void Walk(bool walk)
   {
       animator.SetBool(AnimationTags.WALK_TAG,walk);
   }

   public void Kick()
   {
       animator.SetTrigger(AnimationTags.KICK_TAG);
   }
    public void Punch()
   {
       animator.SetTrigger(AnimationTags.PUNCH_TAG);
   }
    public void Melee()
   {
       animator.SetTrigger(AnimationTags.MELEE_TAG);
   }
    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH_TAG);
    }
}
