using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

    public float limitForX = 0.1f;
    public float limitForY = 0.1f;
    public float dif = 0.05f;
    bool goX = true;
     float addX;
     float addY;

	// Use this for initialization
	void Start () {
        addX = 0.0f;
        addY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (addX <= 0)
        {
            goX = true;
        }

        if (addX >= limitForX)
        {
            goX = false;
        }

        if (goX)
        {
            addX += dif;
        }
        else
        {
            addX -= dif;
        }
        
        this.transform.Translate(addX, 0, 0);
        
	}



    void moveCameraH()
    {
        if (addX == 0)
        {
            addX += dif;
        }

        else if (addX >= limitForX)
        {
            addX -= dif;
        }

    }


    void moveCameraV()
    {
        if (addY == 0)
        {
            addX += dif;
        }

        else if (addY >= limitForX)
        {
            addX -= dif;
        }
    }

}
