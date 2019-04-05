using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    /*
     * the bools are to check if the menu is open or if the player wants to build something.
     * The strings are to where in the menus the player currently is, which law is currently active, or which building is being build.
     * The GameObjects are the menu slides.
     * The placedBuildings list is for the timely check that updates the resources and damage of the buildings.
         */
    bool mainMenuActive = false;
    public bool wantsToBuild = false;
    string currentPanel = "Buildings";
    public string currentlyBuilding = "";
    public string currentLaw = "Cemetary Law";
    public string buttonPressed = "";

    [SerializeField]
    GameObject buildingMenu;
    [SerializeField]
    GameObject lawMenu;

    public List<GameObject> placedBuildings = new List<GameObject>();

    //When the menu button is clicked, it either turns on or off, depending on the current state of the menu. It also checks at which slide you closed the menu, so you can continue from there.
    public void ActivateMenu()
    {
        if(mainMenuActive == false)
        {
            mainMenuActive = true;
            if(currentPanel == "Buildings")
            {
                buildingMenu.SetActive(true);
            }
            else
            {
                lawMenu.SetActive(true);
            }
        }
        else
        {
            mainMenuActive = false;
            buildingMenu.SetActive(false);
            lawMenu.SetActive(false);
        }
    }

    //This function changes the panels based on which button is pressed.
    public void ChangePanel()
    {
        if(currentPanel == "Buildings")
        {
            currentPanel = "Laws";
            buildingMenu.SetActive(false);
            lawMenu.SetActive(true);
        }
        else
        {
            currentPanel = "Buildings";
            lawMenu.SetActive(false);
            buildingMenu.SetActive(true);
        }
    }
    //If a building is selected, the menu gets closed and the function sends which button is pressed to the gridpieceClicks script.
    //It also checks for one of the created laws. You cannot build both the cemetary and the crematory because of this.
    public void SelectBuilding()
    {
        //check resources, then await touch on the grid.
        if((buttonPressed == "Crematory" && currentLaw == "Cemetary Law") || (buttonPressed == "Cemetary" && currentLaw == "Crematory Law"))
        {
            Debug.Log("Sorry, can't let you do that.");
        }
        else
        {
            wantsToBuild = true;
            currentlyBuilding = buttonPressed;
            ActivateMenu();
        }
    }
    //This function virtually does the same as the SelectBuilding function, but with classes. They don't do much within this game yet.
    public void SelectLaw()
    {
        //follow the law rules.
        currentLaw = buttonPressed;
        ActivateMenu();
    }
}
