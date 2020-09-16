using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))     //MeleeAttack
        {
            playerAnimation.Melee();
        }
        if(Input.GetKeyDown(KeyCode.K))     //Kick
        {
            playerAnimation.Kick();
        }
        /*if(Input.GetKeyDown(KeyCode.P))     //Punch
        {
            playerAnimation.Punch();
        }*/
    }
}
