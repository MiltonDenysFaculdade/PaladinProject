using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    private Transform player;
    public Transform thisObject;

    private float objX = 0.0f;
    private float objY = 0.0f;
    private float objZ = 0.0f;


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {

        objX = player.position.x;
        objY = player.position.y;
        objZ = player.position.z;
        thisObject.position = new Vector3(objX, objY, objZ);

	}
}
