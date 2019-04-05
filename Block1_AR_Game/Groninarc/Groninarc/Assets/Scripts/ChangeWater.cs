using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWater : MonoBehaviour {

    Vector3 pos;
    // Use this for initialization
    void Start () {
    }
    // Update is called once per frame
    void Update () {
       
    }
    public void IncLevl()
    {
        pos = transform.position;
        while (pos.y < 34f)
        {
            transform.Translate(0f, 0.0001f, 0f);
            pos = transform.position;
        }
    }
    public void DecLevl()
    {
        pos = transform.position;
        while (pos.y > 30f)
        {
            transform.Translate(0f, -0.0001f, 0f);
            pos = transform.position;
        }
    }
}
