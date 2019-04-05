using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPieceClick : MonoBehaviour {
    
    public GameObject platform;
    GameObject newPlatform;
    public GameObject crematory;
    public GameObject greenhouse;
    public GameObject factory;
    public GameObject house;
    public GameObject school;
    public GameObject cemetary;
    public GameObject hospital;
    public GameObject pump;
    public GameObject government;
    public GameObject windTurbine;
    public GameObject gasDrill;
    public GameObject gasTurbine;
    public GameObject park;

    //Objects that contain important scripts with variables that need to be used.
    GameObject brickSpawner;
    GameObject menuManager;
    GameObject resourceManager;

    public List<int> thisPosition = new List<int>();
    // Use this for initialization
	void Start () {
        brickSpawner = GameObject.Find("brickSpawner");
        menuManager = GameObject.Find("MenuManager");
        resourceManager = GameObject.Find("ResourceManager");
    }


    /*
     *This contains a multiple check for the possiblility to build a platform or building. Some of these contain a power check, which causes confusion within the gameplay, as the buildings don't spawn.
     * All switch statement cases are based on the button pressed in the building menu.
     * All cases have the same lines to instantiate, position and assign variables to buildings.
     * The platform case removes the pre-existing GameObject and places a platform in its place.
     * It also assigns this script and everything it needs to work properly.
     * The pumps have an extra switch statement to check which way they should face.
     * All GridPieceClick scripts are given an x and z coordinate, to make checking the placability easier.
         */
    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (menuManager.GetComponent<MenuManager>().wantsToBuild == true)
        {
            Debug.Log("You May Build");
            switch (menuManager.GetComponent<MenuManager>().currentlyBuilding)
            {
                case "Platform":
                    if ((resourceManager.GetComponent<ResourceManager>().rawMaterial - 1 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 1 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]][this.thisPosition[0]] == 0 && (brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1] - 1][this.thisPosition[0] - 1] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]-1][this.thisPosition[0]] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]][this.thisPosition[0] -1] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]+ 1][this.thisPosition[0]-1] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]+ 1][this.thisPosition[0]] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1] + 1][this.thisPosition[0] + 1] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]][this.thisPosition[0]+ 1] == 1 || brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[1]- 1][this.thisPosition[0] + 1] == 1))//plus check for platform next to the place touched
                    {
                        newPlatform = Instantiate(platform, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        newPlatform.transform.parent = this.transform.parent;
                        newPlatform.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        newPlatform.AddComponent<GridPieceClick>();
                        newPlatform.GetComponent<GridPieceClick>().thisPosition = this.thisPosition;
                        newPlatform.GetComponent<GridPieceClick>().crematory = this.crematory;
                        newPlatform.GetComponent<GridPieceClick>().platform = this.platform;
                        newPlatform.GetComponent<GridPieceClick>().cemetary= this.cemetary;
                        newPlatform.GetComponent<GridPieceClick>().school= this.school;
                        newPlatform.GetComponent<GridPieceClick>().greenhouse = this.greenhouse;
                        newPlatform.GetComponent<GridPieceClick>().house = this.house;
                        newPlatform.GetComponent<GridPieceClick>().factory = this.factory;
                        newPlatform.GetComponent<GridPieceClick>().hospital = this.hospital;
                        newPlatform.GetComponent<GridPieceClick>().pump = this.pump;
                        newPlatform.GetComponent<GridPieceClick>().government = this.government;
                        newPlatform.GetComponent<GridPieceClick>().windTurbine = this.windTurbine;
                        newPlatform.GetComponent<GridPieceClick>().gasDrill = this.gasDrill;
                        newPlatform.GetComponent<GridPieceClick>().gasTurbine = this.gasTurbine;
                        newPlatform.GetComponent<GridPieceClick>().park = this.park;
                        newPlatform.AddComponent<BoxCollider>();
                        newPlatform.GetComponent<BoxCollider>().enabled = true;
                        newPlatform.GetComponent<BoxCollider>().isTrigger = true;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 1;
                        Debug.Log("You lifted the ground!!!");
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 1;
                        resourceManager.GetComponent<ResourceManager>().food -= 1;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                        Destroy(this.gameObject);
                    }
                    break;
                case "Cemetary":
                    if ((resourceManager.GetComponent<ResourceManager>().rawMaterial - 3 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 5 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && /*place for the building*/(brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+2][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+ 2][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] == 1))
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(cemetary, new Vector3(this.transform.position.x + 0.09f, 0.075f, this.transform.position.z + 0.075f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90,-90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Cemetary";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 0;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(cemetary);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+2][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+2][this.thisPosition[1]+1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 3;
                        resourceManager.GetComponent<ResourceManager>().depressionRating += 2;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 3;
                        resourceManager.GetComponent<ResourceManager>().food -= 5;
                        Debug.Log("You placed a cemetary! You must expect quite a lot of dead people!");
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                        break;
                case "Crematory":
                    if ((resourceManager.GetComponent<ResourceManager>().power - 10 >= 0 && resourceManager.GetComponent<ResourceManager>().rawMaterial - 6 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 5 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(crematory, new Vector3(this.transform.position.x + 0.06f, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90,-90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Crematory";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 2;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(crematory);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating -= 1;
                        resourceManager.GetComponent<ResourceManager>().depressionRating += 6;
                        resourceManager.GetComponent<ResourceManager>().power -= 10;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 6;
                        resourceManager.GetComponent<ResourceManager>().food -= 5;
                        Debug.Log("You placed a crematory! You must expect quite a lot of dead people!");
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                        break;
                case "Factory":
                    if ((resourceManager.GetComponent<ResourceManager>().power - 10 >= 0 && resourceManager.GetComponent<ResourceManager>().rawMaterial - 4 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 4 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && (brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 2] == 1  && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 2] == 1))
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(factory, new Vector3(this.transform.position.x + 0.055f, this.transform.position.y + 0.1f, this.transform.position.z + 0.08f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90,-90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Factory";
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(factory);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+2] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+2] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 1;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 3;
                        resourceManager.GetComponent<ResourceManager>().power -= 10;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial += 6;
                        resourceManager.GetComponent<ResourceManager>().food -= 4;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Gas Drill":
                    if (( resourceManager.GetComponent<ResourceManager>().rawMaterial - 1 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 1 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(gasDrill, new Vector3(this.transform.position.x , this.transform.position.y + 0.05f, this.transform.position.z ), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, -90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Gas Drill";
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(gasDrill);
                        resourceManager.GetComponent<ResourceManager>().approvalRating -= 2;
                        resourceManager.GetComponent<ResourceManager>().depressionRating += 2;
                        resourceManager.GetComponent<ResourceManager>().gas += 10;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 1;
                        resourceManager.GetComponent<ResourceManager>().food -= 1;

                    }
                    break;
                case "Gas Turbine":
                    if (( resourceManager.GetComponent<ResourceManager>().rawMaterial - 2 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 3 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(gasTurbine, new Vector3(this.transform.position.x , this.transform.position.y + 0.09f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, 0, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Gas Turbine";
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(gasTurbine);
                        resourceManager.GetComponent<ResourceManager>().approvalRating -= 3;
                        resourceManager.GetComponent<ResourceManager>().depressionRating += 3;
                        resourceManager.GetComponent<ResourceManager>().power += 5;
                        resourceManager.GetComponent<ResourceManager>().gas -= 5;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 2;
                        resourceManager.GetComponent<ResourceManager>().food -= 3;
                    }
                    break;
                case "Government":
                    if (brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(government, new Vector3(this.transform.position.x + 0.055f, this.transform.position.y + 0.05f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, -90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Government";
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(government);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 1] = 2;
                        resourceManager.GetComponent<ResourceManager>().populationCapacity += 20;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Greenhouse":
                    if ((resourceManager.GetComponent<ResourceManager>().power - 8 >= 0 && resourceManager.GetComponent<ResourceManager>().rawMaterial - 6 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 6 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && (brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] ] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] ][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 1] == 1))
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(greenhouse,new Vector3(this.transform.position.x + 0.055f, this.transform.position.y + 0.11f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90,-90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Greenhouse";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 1;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(greenhouse);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 1;
                        resourceManager.GetComponent<ResourceManager>().power -= 8;
                        resourceManager.GetComponent<ResourceManager>().food += 4;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Hospital":
                    if ((resourceManager.GetComponent<ResourceManager>().power - 10 >= 0 && resourceManager.GetComponent<ResourceManager>().rawMaterial - 6 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 6 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+ 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(hospital, new Vector3(this.transform.position.x + 0.055f, this.transform.position.y + 0.11f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, -90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Hospital";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 3;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 3;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(hospital);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1] + 1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 5;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 5;
                        resourceManager.GetComponent<ResourceManager>().power -= 10;
                        resourceManager.GetComponent<ResourceManager>().populationCapacity += 10;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 6;
                        resourceManager.GetComponent<ResourceManager>().food -= 6;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "House":
                    if ((resourceManager.GetComponent<ResourceManager>().power - 2 >= 0 && resourceManager.GetComponent<ResourceManager>().rawMaterial - 2 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 2 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+ 1] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(house, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90,-90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "House";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 1;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(house);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;//also for all other occupied gridpieces
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+ 1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 2;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 2;
                        resourceManager.GetComponent<ResourceManager>().power -= 2;
                        resourceManager.GetComponent<ResourceManager>().populationCapacity += 10;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 2;
                        resourceManager.GetComponent<ResourceManager>().food -= 2;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Park":
                    if (( resourceManager.GetComponent<ResourceManager>().rawMaterial - 2 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 3 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(park, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, 0, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Park";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 1;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(park);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;//also for all other occupied gridpieces
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 3;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 3;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 2;
                        resourceManager.GetComponent<ResourceManager>().food -= 3;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Pump":
                    if ( this.tag == "Pump" && (resourceManager.GetComponent<ResourceManager>().rawMaterial - 8 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 8 >= 0 && resourceManager.GetComponent<ResourceManager>().power - 20 >= 0))
                    {
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 5;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 5;
                        resourceManager.GetComponent<ResourceManager>().power -= 20;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 8;
                        resourceManager.GetComponent<ResourceManager>().food -= 8;
                        switch (this.name)
                        {
                            case "North":
                                GameObject newBuilding;
                                newBuilding = Instantiate(pump, new Vector3(this.transform.position.x, this.transform.position.y , this.transform.position.z + 0.05f), Quaternion.identity);
                                newBuilding.transform.parent = this.transform.parent;
                                newBuilding.transform.Rotate(0, 180, 0);
                                newBuilding.AddComponent<BuildingClass>();
                                newBuilding.GetComponent<BuildingClass>().buildingType = "Pump";
                                newBuilding.GetComponent<BuildingClass>().repairFoodCost = 3;
                                newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 3;
                                newBuilding.GetComponent<BuildingClass>().damage = 0;
                                menuManager.GetComponent<MenuManager>().placedBuildings.Add(pump);
                                Destroy(this.gameObject);
                                break;
                            case "South":
                                
                                newBuilding = Instantiate(pump, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.05f), Quaternion.identity);
                                newBuilding.transform.parent = this.transform.parent;
                                newBuilding.transform.Rotate(0, 0, 0);
                                newBuilding.AddComponent<BuildingClass>();
                                newBuilding.GetComponent<BuildingClass>().buildingType = "Pump";
                                newBuilding.GetComponent<BuildingClass>().repairFoodCost = 3;
                                newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 3;
                                newBuilding.GetComponent<BuildingClass>().damage = 0;
                                Destroy(this.gameObject);
                                menuManager.GetComponent<MenuManager>().placedBuildings.Add(pump);
                                break;
                            case "West":
                                
                                newBuilding = Instantiate(pump, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.05f), Quaternion.identity);
                                newBuilding.transform.parent = this.transform.parent;
                                newBuilding.transform.Rotate(0, 90, 0);
                                newBuilding.AddComponent<BuildingClass>();
                                newBuilding.GetComponent<BuildingClass>().buildingType = "Pump";
                                newBuilding.GetComponent<BuildingClass>().repairFoodCost = 3;
                                newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 3;
                                newBuilding.GetComponent<BuildingClass>().damage = 0;
                                Destroy(this.gameObject);
                                menuManager.GetComponent<MenuManager>().placedBuildings.Add(pump);
                                break;
                            default:
                                Debug.Log("This will probably never be called.");
                                break;
                        }
                    }
                    break;
                case "School":
                    if (( resourceManager.GetComponent<ResourceManager>().rawMaterial - 3 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 3 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1 && (brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0] + 1][this.thisPosition[1]] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1] + 1] == 1 && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] == 1))
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(school, new Vector3(this.transform.position.x + 0.05f, this.transform.position.y + 0.1f, this.transform.position.z + 0.05f), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, -90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "School";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 0;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(school);
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]+1] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]] = 2;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]+1][this.thisPosition[1]+1] = 2;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 3;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 6;
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 3;
                        resourceManager.GetComponent<ResourceManager>().food -= 3;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                case "Wind Turbine":
                    if (( resourceManager.GetComponent<ResourceManager>().rawMaterial - 3 >= 0 && resourceManager.GetComponent<ResourceManager>().food - 4 >= 0) && brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] == 1)
                    {
                        GameObject newBuilding;
                        newBuilding = Instantiate(windTurbine, new Vector3(this.transform.position.x , this.transform.position.y + 0.01f, this.transform.position.z ), Quaternion.identity);
                        newBuilding.transform.parent = this.transform.parent;
                        newBuilding.transform.Rotate(-90, -90, 0);
                        newBuilding.AddComponent<BuildingClass>();
                        newBuilding.GetComponent<BuildingClass>().buildingType = "Wind Turbine";
                        newBuilding.GetComponent<BuildingClass>().repairFoodCost = 1;
                        newBuilding.GetComponent<BuildingClass>().repairRawMaterialCost = 0;
                        newBuilding.GetComponent<BuildingClass>().damage = 0;
                        menuManager.GetComponent<MenuManager>().placedBuildings.Add(windTurbine);
                        resourceManager.GetComponent<ResourceManager>().rawMaterial -= 3;
                        resourceManager.GetComponent<ResourceManager>().food -= 4;
                        resourceManager.GetComponent<ResourceManager>().approvalRating += 1;
                        resourceManager.GetComponent<ResourceManager>().depressionRating -= 1;
                        resourceManager.GetComponent<ResourceManager>().power += 4;
                        brickSpawner.GetComponent<GridWorks>().buildablePlatforms[this.thisPosition[0]][this.thisPosition[1]] = 2;
                        menuManager.GetComponent<MenuManager>().wantsToBuild = false;
                    }
                    break;
                default:
                    Debug.Log("Sorry, can't let you do that...");
                    break;

            }
        }
        else
        {
            Debug.Log("Sorry, can't let you do that.");
        }
    }
}
