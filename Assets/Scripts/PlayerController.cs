using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    //private bool keyDown = false;

    public float walkSpeed = 2f;
    public float runSpeed = 8f;
    float currentSpeed;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;


    bool grounded = false;
    bool jumping = false;
    float attackTimer = 0.0f;
    int attackIterator = 0;
    
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


        float animationSpeedPercent = ((walking) ? 0.5f : 1f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

        if (attackIterator == 0)
        {
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }


        if (Input.GetMouseButtonUp(0) && grounded)
        {
            attackIterator += 1;
            //Debug.Log("Attack Iterator " + attackIterator);
            attack();
        }
        
        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            jumping = true;
            this.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(0, 7.0f, 0);
            animator.SetBool("jumping", jumping);
        }

	}




    void LateUpdate()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.green, -0.5f);
        if (Physics.Raycast(transform.position, -transform.up, -1.2f))
        {
            grounded = true;
            jumping = false;
            animator.SetBool("jumping", jumping);
            //Debug.Log("Grounded!");
        }
        else
        {
            grounded = false;
            //Debug.Log("Not grounded!");
        }



        if (attackIterator > 0)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > 0.80f)
            {
                attackIterator = 0;
                animator.SetInteger("attackIterator", attackIterator);
            }
        }


    }





    void attack()
    {

            if (attackIterator > 0)
            {
                attackTimer = 0;
                animator.SetInteger("attackIterator", attackIterator);
            }
            else if (attackIterator > 1)
            {
                attackTimer = 0;
                animator.SetInteger("attackIterator", attackIterator);
            }
            else if (attackIterator > 2)
            {
                attackTimer = 0;
                animator.SetInteger("attackIterator", attackIterator);
            }


    }


}
