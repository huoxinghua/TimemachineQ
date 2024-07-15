using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{   
    [SerializeField] Transform topPoint;
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    [SerializeField] float moveSpeed = 5f;

    bool _isMoving = false;
   

    void Start()
    {
        targetPosition = topPoint.position;
        initialPosition = transform.position;


    }
    
    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Debug.Log($"Elevator position: {transform.position}, Target position: {targetPosition}");
            if (Vector3.Distance(transform.position,targetPosition)<0.1f)
            {
                _isMoving = false;
            }
        }
    }
    public void MoveToTop()
    {
        
        targetPosition = topPoint.position;
        _isMoving = true;
    }

    public void MoveToInitial()
    {
        targetPosition = initialPosition;
        _isMoving = true;
    }


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
