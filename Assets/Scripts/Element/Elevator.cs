using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    [SerializeField] Transform bottomPoint;
    [SerializeField] Transform topPoint;
    [SerializeField] private int _currentTargetPosition = 0;
    [SerializeField] private int _nextTargetPosition = 1;
    [SerializeField] GameObject topSwitch;
    [SerializeField] GameObject bottomSwitch;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] GameObject elevatorPlatfom;
    private float _minTargetDistance = 0.01f;
    bool _isMoving = false;
    bool _isInBottom = true;
    bool _isInTop = true;

    [SerializeField]  private SwitchButtonController switchButtonController;
    

    void Start()
    {
        //elevatorPlatfom.transform.position = bottomPoint.transform.position;
        _isInBottom = true;

        //find ref of switch
      
        switchButtonController = GetComponentInChildren<SwitchButtonController>();
       
    }
    public IEnumerator MoveElevator()
    {
        float alpha = 0.0f;
        while (true)
        {
            alpha += Time.fixedDeltaTime * moveSpeed;
            if ((1.0f - alpha) < _minTargetDistance)
            {
                _nextTargetPosition++;
                _currentTargetPosition++;
                _nextTargetPosition %= movePoints.Length;
                _currentTargetPosition %= movePoints.Length;
                alpha = 1f;
            }
           
                elevatorPlatfom.transform.position = Vector3.Lerp(
                movePoints[_currentTargetPosition].transform.position,
                movePoints[_nextTargetPosition].transform.position, alpha
                    );
           

            
            yield return new WaitForFixedUpdate();
        }

    }
    public void StartMoving()
    {
        StartCoroutine(MoveElevator());
        Debug.Log("Move in elevator in elevator");
    }
  
    //another way to try
    // this.transform.position = movePoints[_currentTargetPosition].transform.position;
    
    /*
    float alpha = 0.0f;

    void FixedUpdate()
    {
       
        if (switchButtonController.isPressedSwitch)
        {
            alpha += Time.deltaTime * moveSpeed;  
            alpha = Mathf.Clamp01(alpha);

            StartMoving();
        }
    }
    
    public void StartMoving()
    {
        Debug.Log("move now");
        elevatorPlatfom.transform.position = Vector3.Lerp(
               topPoint.transform.position,
               bottomPoint.transform.position,
              1f);
      /*  if (elevatorPlatfom.transform.position == topPoint.position)
        {
            elevatorPlatfom.transform.position = Vector3.Lerp(
                topPoint.transform.position,
                bottomPoint.transform.position,
               1f);
        }
        else if (elevatorPlatfom.transform.position == bottomPoint.position)
        {
            elevatorPlatfom.transform.position = Vector3.Lerp(
               bottomPoint.transform.position,
               topPoint.transform.position,
              1f);
        }
      
    }

    public void StopElevator()
    {
      
    }*/


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.GetComponent<PlayerController>())
        {
            other.collider.GetComponent<PlayerController>().AttachToParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.GetComponent<PlayerController>())
        {
            other.collider.GetComponent<PlayerController>().AttachToParent(null);
        }
    }
}
