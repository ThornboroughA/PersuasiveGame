using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    private Vector3 rotation;

    //character control
    public float movementSpeed = 5.0f;
    public int rotationSpeed = 130;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        //Variable Declaratoin
        //float x;
        

        //Control
        if (characterController.isGrounded)
        {
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = moveDirection * movementSpeed;
        }
        //Rotation
        //x = Input.GetAxis("Mouse X") * -1.5f; //rotation based on mouse control
        //this.rotation = new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
        //this.transform.Rotate(this.rotation);

        //Gravity
        moveDirection.y -= 10f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
