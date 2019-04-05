using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factions : MonoBehaviour {
    public Text AmountOfPeopleText;
    
    public int PopulationCount;

    // Use this for initialization
    void Start ()
    {
        PopulationCount = 30;
        PeopleCounter();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void PeopleCounter()
    {
        AmountOfPeopleText.text = "Population:" + PopulationCount.ToString();
    }
}