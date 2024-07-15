using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorSwitch : MonoBehaviour
{
    
    [SerializeField] public Elevator elevator;
    [SerializeField] PlayerController playerController;
    
    private float _switchSizeY;
    private Vector3 _switchUpPos;
    private Vector3 _switchDownPos;
    public float _switchSpeed =2f;
   
    private bool isPressed = false;

    private void Start()
    {
        transform.position = _switchUpPos;
    }

    private void Awake()
    {
        //the Elevator Reference
        elevator = GameObject.FindObjectOfType<Elevator>();
        //calculate the y value to move up and down
        _switchUpPos = transform.position;
        _switchSizeY = transform.localScale.y / 2;
        _switchDownPos = new Vector3(transform.position.x,transform.position.y - _switchSizeY, transform.position.z);
    }

    // update the isPressed state of the switch
    private void Update()
    {
        if (isPressed)
        {
            // Move the switch down
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
        else
        {
            // Move the switch up
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    //use the colllider to checck the player is on the switch
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            isPressed = true;
            elevator.MoveToTop();


        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.GetComponent<PlayerController>() != null)
        {
            isPressed = false;
            elevator.MoveToInitial();
        }
    }
}
