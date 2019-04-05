using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCallOut : MonoBehaviour
{
    //This class/function is used to check which button is pressed within the build/law menu. This is a string used inside the MenuManager script.
    [SerializeField]
    GameObject menuManager;

    public void OnMouseDown()
    {
        menuManager.GetComponent<MenuManager>().buttonPressed = this.gameObject.name;
    }
}
