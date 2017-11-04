using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBehavior : MonoBehaviour
{

    Animator animator;
    GameObject targetPosition;

    public int life = 100;
    public float farFromPlayer = 1.8f;
    public float speed = 0.05f;

    private int setAnim = 0;

    public static bool attacking = false;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        targetPosition = GameObject.FindGameObjectWithTag("Player");

        animator.SetBool("moving", false);

	}
	
	// Update is called once per frame
	void Update () {

        if (life > 0)
        {

            var rotationAngle = Quaternion.LookRotation(targetPosition.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 5);

            if (Vector3.Distance(this.transform.position, targetPosition.transform.position) > 15)
            {
                animator.SetBool("moving", false);
            }

            else if (Vector3.Distance(this.transform.position, targetPosition.transform.position) > farFromPlayer)
            {
                animator.SetBool("moving", true);
                animator.SetInteger("attack_iterator", 0);
                transform.Translate(Vector3.forward * speed, Space.Self);
                
            }
            else if (Vector3.Distance(this.transform.position, targetPosition.transform.position) <= farFromPlayer)
            {
                animator.SetBool("moving", false);
                animator.SetInteger("attack_iterator", Random.Range(1, 3) );
                attacking = true;
            }
            
        }

        else if (life <= 0)
        {
            animator.SetInteger("attack_iterator", 0);
            animator.SetBool("dead", true);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject, 10);

        }


        animator.SetFloat("setAnimation", 1);


		
	}

    
    

}
