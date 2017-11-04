using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {

    //MonsterBehavior behavior;

	// Use this for initialization
	void Start () {
       //behavior = this.GetComponent<MonsterBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    
    void OnTriggerEnter(Collider hit)
    {

        if (hit.tag == "Player")
        {
            MonsterBehavior.attacking = false;
            //Debug.Log("Monster hit!");

        }

    }
    


}
