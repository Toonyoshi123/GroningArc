using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour {

    public bool truning = true;
    public KeyCode onButton = KeyCode.F;
    public KeyCode offButton = KeyCode.G;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (truning)
        {
            transform.Rotate(0f, 0f, -1f);
        }
        if (Input.GetKey(onButton))
        {
            truning = true;
        }
        if (Input.GetKey(offButton))
        {
            truning = false;
        }
    }
}
