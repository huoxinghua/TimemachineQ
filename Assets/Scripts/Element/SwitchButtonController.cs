using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class SwitchButtonController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Y;
    [SerializeField]private Elevator elevator;
    [SerializeField] PlayerController playerController;
    private Transform deafaultPosition;
    //[SerializeField] private PlayerInputController.PlayerType playerType;

    private float _switchSizeY;
    private Vector3 _switchUpPos;
    private Vector3 _switchDownPos;
    public float _switchSpeed =2f;
    float _switchDelay = 0.2f;

    public bool isPressedSwitch = false;
    private void Start()
    {
        transform.position = _switchUpPos = transform.position;
    }

    private void Awake()
    {
        //the Elevator Refence
        elevator = GetComponentInParent<Elevator>();

        _switchUpPos = transform.position;
        Debug.Log(" upPos" + _switchUpPos);

        _switchSizeY = transform.localScale.y / 2;
        _switchDownPos = new Vector3(transform.position.x,transform.position.y - _switchSizeY, transform.position.z);
        Debug.Log(" downPos" + _switchDownPos);
     
    }

    public void ToggleSwitch()
    {
      
        elevator.StartMoving();
    }
    void MoveSwitchDown()
    {
        if (!isPressedSwitch)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed);
            ToggleSwitch();
            isPressedSwitch = true;
        } 
    }
    private void MoveSwitchUp()
    {
        if (isPressedSwitch)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed );
            isPressedSwitch = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {  
      
           // Debug.Log("hit player");
            MoveSwitchDown();
        
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BluePlayer") || collision.CompareTag("RedPlayer"))
        {
            Debug.Log("player leave");
            MoveSwitchUp();
        }
        
         StartCoroutine(SwitchUpDelay(_switchDelay));
      
    }
    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isPressedSwitch = true;
       
    }
}
