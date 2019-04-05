using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWorks : MonoBehaviour {
    //possibly changable size for the starting grid.
    int lengthGrid = 18;
    int widthGrid = 18;
    //All models that need to be either passed onto the next script to prevent extra workload, or need to be loaded using this script.
    [SerializeField]
    GameObject gridPrefab;
    GameObject parentObject;
    [SerializeField]
    GameObject buildable;
    GameObject currentInstance;
    [SerializeField]
    GameObject crematory;
    GameObject martiniTower;
    [SerializeField]
    GameObject factory;
    [SerializeField]
    GameObject greenHouse;
    [SerializeField]
    GameObject house;
    [SerializeField]
    GameObject school;
    [SerializeField]
    GameObject cemetary;
    [SerializeField]
    GameObject hospital;
    [SerializeField]
    GameObject pump;
    [SerializeField]
    GameObject government;
    [SerializeField]
    GameObject windTurbine;
    [SerializeField]
    GameObject gasDrill;
    [SerializeField]
    GameObject gasTurbine;
    [SerializeField]
    GameObject park;

    //Variable that saves which grids are buildable platforms or green mud.
    public List<List<int>> buildablePlatforms = new List<List<int>>();
    //The resource manager, which has a function that can speed up the in-game time.
    GameObject resourceManager;

    //Update rotates the martini windmill. In any next changes, this or gridPieceClick should also animate the wind turbines.
    private void Update()
    {
        martiniTower.transform.Rotate(0,-30 * Time.deltaTime * resourceManager.GetComponent<ResourceManager>().speedUp, 0 , Space.Self);
    }

    /*Creates the starting grid depending on the given size. Each piece gets the GridPieceClick script and all models.
     * But it first needs a parentObject to make sure everything only shows when the AR works as well.
     * The zeroPoints are to make sure the middle is the middle inside this game.
     */
    void Start () {
        martiniTower = GameObject.Find("Plane.001");
        parentObject = GameObject.Find("ImageTarget");
        resourceManager = GameObject.Find("ResourceManager");
        float zeroPointX = (-widthGrid * 0.5f + 0.5f);
        float zeroPointZ = (-lengthGrid * 0.5f + 0.5f);

        for (int x = 0; x < widthGrid; x++)
        {

            List<int> xCoordinate = new List<int>();

            for (int z = 0; z < lengthGrid; z++)
            {

                if (z > 5 && z < 12 && x > 5 && x < 12)
                {
                    if ((z == 9 || z == 10) && (x == 9 || x == 10))
                    {
                        xCoordinate.Add(2);
                    }
                    else
                    {
                        xCoordinate.Add(1);
                    }

                    currentInstance = Instantiate(buildable, parentObject.transform);
                    currentInstance.AddComponent<GridPieceClick>();
                    currentInstance.GetComponent<GridPieceClick>().thisPosition.Add(x);
                    currentInstance.GetComponent<GridPieceClick>().thisPosition.Add(z);
                    currentInstance.GetComponent<GridPieceClick>().crematory = this.crematory;
                    currentInstance.GetComponent<GridPieceClick>().platform = this.buildable;
                    currentInstance.GetComponent<GridPieceClick>().greenhouse = this.greenHouse;
                    currentInstance.GetComponent<GridPieceClick>().house = this.house;
                    currentInstance.GetComponent<GridPieceClick>().factory = this.factory;
                    currentInstance.GetComponent<GridPieceClick>().school = this.school;
                    currentInstance.GetComponent<GridPieceClick>().cemetary = this.cemetary;
                    currentInstance.GetComponent<GridPieceClick>().hospital = this.hospital;
                    currentInstance.GetComponent<GridPieceClick>().pump = this.pump;
                    currentInstance.GetComponent<GridPieceClick>().government = this.government;
                    currentInstance.GetComponent<GridPieceClick>().windTurbine = this.windTurbine;
                    currentInstance.GetComponent<GridPieceClick>().gasDrill = this.gasDrill;
                    currentInstance.GetComponent<GridPieceClick>().gasTurbine = this.gasTurbine;
                    currentInstance.GetComponent<GridPieceClick>().park = this.park;
                    currentInstance.AddComponent<BoxCollider>();
                    currentInstance.GetComponent<BoxCollider>().enabled = true;
                    currentInstance.GetComponent<BoxCollider>().isTrigger = true;

                    currentInstance.gameObject.transform.SetPositionAndRotation(new Vector3((zeroPointX + x)/10, 0, (zeroPointZ + z)/10), Quaternion.identity);
                    currentInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                }
                else
                {
                    currentInstance = Instantiate(gridPrefab, parentObject.transform);
                    currentInstance.AddComponent<GridPieceClick>();
                    currentInstance.GetComponent<GridPieceClick>().thisPosition.Add(x);
                    currentInstance.GetComponent<GridPieceClick>().thisPosition.Add(z);
                    currentInstance.GetComponent<GridPieceClick>().platform = this.buildable;
                    currentInstance.GetComponent<GridPieceClick>().greenhouse = this.greenHouse;
                    currentInstance.GetComponent<GridPieceClick>().crematory = this.crematory;
                    currentInstance.GetComponent<GridPieceClick>().house = this.house;
                    currentInstance.GetComponent<GridPieceClick>().factory = this.factory;
                    currentInstance.GetComponent<GridPieceClick>().school = this.school;
                    currentInstance.GetComponent<GridPieceClick>().cemetary = this.cemetary;
                    currentInstance.GetComponent<GridPieceClick>().hospital = this.hospital;
                    currentInstance.GetComponent<GridPieceClick>().pump = this.pump;
                    currentInstance.GetComponent<GridPieceClick>().government = this.government;
                    currentInstance.GetComponent<GridPieceClick>().windTurbine = this.windTurbine;
                    currentInstance.GetComponent<GridPieceClick>().gasDrill = this.gasDrill;
                    currentInstance.GetComponent<GridPieceClick>().gasTurbine = this.gasTurbine;
                    currentInstance.GetComponent<GridPieceClick>().park = this.park;
                    currentInstance.GetComponent<BoxCollider>().isTrigger = true;


                    xCoordinate.Add(0);
                    currentInstance.gameObject.transform.SetPositionAndRotation(new Vector3((zeroPointX + x)/10, 0, (zeroPointZ + z)/10), Quaternion.identity);
                    currentInstance.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                }


            }

            buildablePlatforms.Add(xCoordinate);
        }
    }
       
    
}
