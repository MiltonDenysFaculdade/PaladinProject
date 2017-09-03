﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    //private bool keyDown = false;

    public float walkSpeed = 4f;
    public float runSpeed = 10f;
    float currentSpeed;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    
    
    
    Animator animator;

    Transform cameraT;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
	}
	


	// Update is called once per frame
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool walking = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((walking) ? walkSpeed : runSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        
        float animationSpeedPercent = ((walking) ? 0.5f : 1f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        


	}
    
    
    


}
