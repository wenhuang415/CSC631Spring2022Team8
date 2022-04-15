using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed;
   [SerializeField] private float walkSpeed;
   [SerializeField] private float runSpeed;
   [SerializeField] private float jumpHeight;
   
   private Vector3 moveDirection;
   private Vector3 velocity;

   [SerializeField] private bool isGrounded;
   [SerializeField] private float groundDistanceCheck;
   [SerializeField] private LayerMask groundMask;
   [SerializeField] private float gravity;

   private CharacterController controller;
   private Animator anim;

   private void Start()
   {
       controller = GetComponent<CharacterController>();
       anim = GetComponentInChildren<Animator>();
   }

   private void Update()
   {
       Move();
   }

   private void Move()
   {
       isGrounded = Physics.CheckSphere(transform.position, groundDistanceCheck, groundMask);

       
       float moveZ = Input.GetAxis("Vertical");

       moveDirection = new Vector3(0, 0, moveZ);
       moveDirection = transform.TransformDirection(moveDirection);

       if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }

        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        else if(moveDirection == Vector3.zero)
        {
            Idle();
        }

        moveDirection *= moveSpeed;

        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

       controller.Move(moveDirection * Time.deltaTime);

       velocity.y += gravity * Time.deltaTime;
       controller.Move(velocity * Time.deltaTime);
   }

   private void Idle()
   {
       anim.SetFloat("Speed", 0);
   }

   private void Walk()
   {
       moveSpeed = runSpeed;
       anim.SetFloat("Speed", 0.5f);
   }

   private void Run()
   {
       moveSpeed = runSpeed;
       anim.SetFloat("Speed", 1);
   }

   private void Jump()
   {
       velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
   }


}