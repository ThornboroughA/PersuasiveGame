﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    private Vector3 rotation;

    //character control
    public float movementSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController characterController;



    public int toolInt; //1 for pickaxe //2 for axe //3 for sickle

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
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = moveDirection * movementSpeed;

          
        }

        if (moveDirection != Vector3.zero)
        	transform.forward = moveDirection * Time.deltaTime;
        

        //Gravity
        moveDirection.y -= 10f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void CurrentTool(int tool)
    {
        toolInt = tool;
        Debug.Log("tool");

    }
}
