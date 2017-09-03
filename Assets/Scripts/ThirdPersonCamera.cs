using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCamera : MonoBehaviour {
	
	
	private float mouseX = 0.0f;
	private float mouseY = 0.0f;
	private float distance = 3.0f;

    public float sensivity = 1.8f;

    private Camera camera;
    private Transform player;

    RaycastHit hit = new RaycastHit();
    private float cameraAdj = 0.3f;
	
	// Use this for initialization
	void Start () {
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("cameraTarget").transform;
        
	}
	
	
	// Update is called once per frame
    void LateUpdate()
    {
        
        distance -= Input.GetAxis("Mouse ScrollWheel") * sensivity;
        distance = Mathf.Clamp(distance, 1.0f, 8.0f);
        //Transladar câmera em movimento angular em torno do personagem
        camera.transform.RotateAround(player.position, camera.transform.up, Input.GetAxis("Mouse X") * sensivity);
        camera.transform.RotateAround(player.position, camera.transform.right, -Input.GetAxis("Mouse Y") * sensivity);
        //Travar vetor de rotação no eixo Z
        Vector3 rotation = transform.eulerAngles;
        rotation.z = 0;
        transform.eulerAngles = rotation;
        //Definir posição da câmera com referência da posição do personagem
        camera.transform.position = player.position - camera.transform.forward * distance;
        //Colisão da câmera
        if (Physics.Linecast(player.position, transform.position, out hit))
        {
            transform.position = hit.point + transform.forward * cameraAdj;
        }

	}
	
	
	
	
	
	
	
}
