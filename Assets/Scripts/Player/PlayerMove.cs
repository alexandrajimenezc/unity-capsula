using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    private float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 3f;

    Vector3 velocity;

    
    void Update()
    {
        //VERIFICAR suelo

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        
        //Movimiento
        
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //Gravedad

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);


       // salto
       //KeyCode.tecla para una tecla especifica
       if(Input.GetKeyDown("space")  && isGrounded)
       {
           // formula matematica del salto
           velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
       }


        }
}
