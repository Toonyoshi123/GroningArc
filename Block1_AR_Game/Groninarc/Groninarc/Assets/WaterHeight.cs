using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterHeight : MonoBehaviour {
    // every 10 seconds the y position of the water should change between 30 and 34
    float timeLeft = 540;
    // Use this for initialization
    float x;
    float y;
    float z;
    Vector3 pos;
    public Text WarningText;
    bool TurnOn = false;
   // public Text AmountOfPeopleText;

   // public int PopulationCount;

    void Start()
    {
        transform.Translate(0, 30, 0);
        //PopulationCount = 30;
        //PeopleCounter();
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        Debug.Log(timeLeft);
        if (timeLeft >= 0.8f && timeLeft <= 1 && TurnOn == false)
        {
            x = 635;
            y = Random.Range(34, 40);
            z = 743;
            pos = new Vector3(x, y, z);
            transform.position = pos;
            timeLeft = 540;
        }

        if (timeLeft >= 0.8f && timeLeft <= 1 && TurnOn == true)
        {
            x = 635;
            y = Random.Range(30, 34);
            z = 743;
            pos = new Vector3(x, y, z);
            transform.position = pos;
            timeLeft = 540;
        }


        if (timeLeft >= 59.98f && timeLeft <= 60)
        {
            WarningMessage();
        }

        if (timeLeft >= 179.98f && timeLeft <= 180)
        {
            x = 635;
            y = Random.Range(30, 34);
            z = 743;
            pos = new Vector3(x, y, z);
            transform.position = pos;
        }

        if (timeLeft >= 359.98f && timeLeft <= 360)
        {
            x = 635;
            y = Random.Range(30, 34);
            z = 743;
            pos = new Vector3(x, y, z);
            transform.position = pos;
        }
    }

    void WarningMessage()
    {
        WarningText.text = "Don't forget to put on the pumps for the upcoming storm. Otherwise the city might flood";
    }

    public void TurnOnPump()
    {
        TurnOn = true;
        Debug.Log(TurnOn);
    }

    public void TurnOffPump()
    {
        TurnOn = false;
        Debug.Log(TurnOn);
    }

    //public void PeopleCounter()
    //{
    //    AmountOfPeopleText.text = "Population:" + PopulationCount.ToString();
    //}
}