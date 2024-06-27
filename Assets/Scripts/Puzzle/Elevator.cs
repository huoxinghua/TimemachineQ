using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    [SerializeField] float moveSpeed = 5f;
    private int _currentTargetPosition = 0;
    private int _nextTargetPosition = 1;




    void Start()
    {
        this.transform.position = this.movePoints[0].transform.position;
        StartCoroutine(MoveElevator());
        
    }

    IEnumerable MoveElevator()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
