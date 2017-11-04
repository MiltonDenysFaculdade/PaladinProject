using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour {

    PlayerController playerController;
    int counter = 0;

	// Use this for initialization
	void Start () {
        playerController = GameObject.Find("Paladin").GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Enemy" && playerController.attackController)
        {
            playerController.attackController = false;
            counter++;
            hit.gameObject.GetComponent<MonsterBehavior>().life -= 25;
            Debug.Log("Sword hit! " + counter);
        }
        
    }

    


}
