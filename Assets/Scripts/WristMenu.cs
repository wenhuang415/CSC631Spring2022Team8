using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    
    public bool activeWristUI = true;
    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }
    public void MenuPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
            DisplayWristUI();
    }
    // Update is called once per frame
    public void DisplayWristUI()
    {
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if(!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }
}
