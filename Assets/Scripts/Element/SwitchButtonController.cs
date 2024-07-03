using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButtonController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Y;
    [SerializeField]private Elevator elevator;
    [SerializeField] PlayerController playerController;
    //[SerializeField] private PlayerInputController.PlayerType playerType;
    
    private void Awake()
    {
        //the Elevator script is in the parent of the Switch, so need get component in parent
        elevator = GetComponentInParent<Elevator>();

        // Find the PlayerInputController with the specified PlayerType
       
    }
    private void Start()
    {
        //elevator.StartMoving();
    }

    void Update()
    {
       
    }
    public void ToggleSwitch()
    {
        Debug.Log("Y get and move");
        elevator.StartMoving();
    }

 
}
