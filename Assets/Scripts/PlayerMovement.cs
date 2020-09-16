using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    private CharacterAnimations playerAnimations;
    public float playerMoveSpeed = 3f;
    public float gravity = 9.8f;
    public float playerRotateSpeed= 0.15f;
    public float rotateDegreesPerSec = 180f;
    public Vector3 moveDirection;
    public Vector3 rotationDirection = Vector3.zero;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        if(Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime; //this is for applying gravity to the player
            characterController.Move(moveDirection * playerMoveSpeed * Time.deltaTime);
        }
        else if(Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            moveDirection = -transform.forward;     //going back
            moveDirection.y -= gravity * Time.deltaTime; //this is for applying gravity to the player
            characterController.Move(moveDirection * playerMoveSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }
      

    }

    void Rotate()
    {
        rotationDirection = Vector3.zero;       //need to reset it everytime unless there is an input
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            
            rotationDirection = transform.TransformDirection(Vector3.left);
            /*if(characterController.velocity.sqrMagnitude == 0f)
            {
                 rotationDirection = transform.TransformDirection(Vector3.zero);
                 characterController.Move(new Vector3(1f,0,0));
                 playerAnimations.Walk(true);
            }*/
           
        }
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if(rotationDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection),rotateDegreesPerSec * Time.deltaTime);
        }
    }

    private void AnimateWalk()
    {
        if(characterController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }
}
