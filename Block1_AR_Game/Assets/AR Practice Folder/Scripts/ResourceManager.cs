using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {
    //These are all resources that are used for the UI, except for the produced[var] variables.
    public int rawMaterial ;
    public int producedRawMaterial ;
    public int food;
    public int producedFood ;
    public int power ;
    public int gas ;
    public int populationCapacity ;
    int population ;
    public int approvalRating ;
    public int depressionRating ;

    //These variables control the functions in this script
    float timePerDay = 180;
    int waterLevel = 0;
    int currentDay = 1;
    public int speedUp = 1;
    bool hasBeenRead = false;

    GameObject menuManager;
    
    //The UI elements that are turned visible/invisible
    [SerializeField]
    GameObject popUp;
    [SerializeField]
    GameObject popUpImage;
    [SerializeField]
    Text popUpText;

    //The pictures for the factions
    [SerializeField]
    Material elderly;
    [SerializeField]
    Material students;
    [SerializeField]
    Material working;
    [SerializeField]
    Material kids;

    //The UI resouce indicators
    GameObject foodText;
    GameObject rawMaterialText;
    GameObject powerText;
    GameObject populationText;
    GameObject capacityText;
    GameObject ratingText;

    //sets all start variables, GameObjects and texts
    void Start () {
        menuManager = GameObject.Find("MenuManager");
        foodText = GameObject.Find("Food Text");
        rawMaterialText = GameObject.Find("Raw Material Text");
        powerText = GameObject.Find("Power Text");
        populationText = GameObject.Find("Population Text");
        capacityText = GameObject.Find("Capacity Text");
        ratingText = GameObject.Find("Rating Text");

        food = 60;
        producedFood = 15;
        rawMaterial = 30;
        producedRawMaterial = 5;
        power = 5;
        gas = 0;
        populationCapacity = 30;
        population = 30;
        approvalRating = 70;
        depressionRating = 30;
    }

    void Update() {

        timePerDay -= Time.deltaTime * speedUp;

        //Updated text, to make sure the right variables are shown
        foodText.GetComponent<Text>().text = ": " + food;
        rawMaterialText.GetComponent<Text>().text = ": " + rawMaterial;
        powerText.GetComponent<Text>().text = ": " + power;
        populationText.GetComponent<Text>().text = ": " + population;
        capacityText.GetComponent<Text>().text = ": " + populationCapacity;
        ratingText.GetComponent<Text>().text = ": " + approvalRating + "%";

        //Daily update
        if (timePerDay <= 0)
        {
            food += producedFood;
            rawMaterial += producedRawMaterial;
            //population += Mathf.RoundToInt((((1 - depressionRating) * 100) - ((1 - approvalRating) * 100)) / 30);
			population += 2;
            hasBeenRead = false;
            if (approvalRating < 0)
            {
                approvalRating = 0;
            }
            else if (approvalRating > 100)
            {
                approvalRating = 100;
            }

            if (depressionRating < 0)
            {
                depressionRating = 0;
            }
            else if (depressionRating > 100)
            {
                depressionRating = 100;
            }
            timePerDay = 180;
            currentDay++;

        }

        //Creates a different popUp every ingame day.
        if (currentDay == 1 && hasBeenRead == false)
        {
            popUpImage.GetComponent<Image>().material = elderly;
            popUp.GetComponent<Image>().color = new Color32(95, 79, 152, 255);//blue
            popUpText.GetComponent<Text>().text = "Our population is growing. We\n would like a few extra houses.";
            hasBeenRead = true;
            popUp.gameObject.SetActive(true);
        }
         else if (currentDay == 2 && hasBeenRead == false)
        {
            popUpImage.GetComponent<Image>().material = students;
            popUp.GetComponent<Image>().color = new Color32(181, 79, 23, 255);//red
            popUpText.GetComponent<Text>().text = "We would like to go to school.";
            hasBeenRead = true;
            popUp.gameObject.SetActive(true);
        }
        else if (currentDay == 3 && hasBeenRead == false)
        {
            popUpImage.GetComponent<Image>().material = kids;
            popUp.GetComponent<Image>().color = new Color32(181, 165, 45, 255);//yellow
            popUpText.GetComponent<Text>().text = "Our kids would like to play in a park.";
            hasBeenRead = true;
            popUp.gameObject.SetActive(true);
        }
        else if (currentDay == 4 && hasBeenRead == false)
        {
            popUpImage.GetComponent<Image>().material = working;
            popUp.GetComponent<Image>().color = new Color32(87, 165, 45, 255);//green
            popUpText.GetComponent<Text>().text = "We would like a place to work. \nMaybe a factory?";
            hasBeenRead = true;
            popUp.gameObject.SetActive(true);
        }
    }

    //If the speedUp button is pressed, the ingame time either sppeds up 3 times, or slows down to real time.
    public void SpeedUpButton()
    {
        if(speedUp == 1)
        {
            speedUp = 3;
        }
        else
        {
            speedUp = 1;
        }
    }

    //When the popUp is pressed upon, it disappears
    public void OnMouseDown()
    {
        popUp.gameObject.SetActive(false);
        Debug.Log("inActive");
    }
}
