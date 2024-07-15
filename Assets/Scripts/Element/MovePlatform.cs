using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform[] movePoints;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private int _currentTargetPosition = 0;
    [SerializeField] private int _nextTargetPosition = 1;
    private float _minTargetDistance = 0.01f;




    void Start()
    {
        this.transform.position = this.movePoints[0].transform.position;
        StartCoroutine(MoveElevator());  
    }


    IEnumerator MoveElevator()
    {
        float alpha = 0.0f;
        while(true)
        {
            alpha += Time.fixedDeltaTime * moveSpeed;
            if((1.0f - alpha) < _minTargetDistance)
            {
                _nextTargetPosition++;
                _currentTargetPosition++;
                _nextTargetPosition %= movePoints.Length;
                _currentTargetPosition %= movePoints.Length;
                alpha = 0f;
            }
        
        
            this.transform.position = Vector3.Lerp(
                this.movePoints[_currentTargetPosition].transform.position,
                this.movePoints[_nextTargetPosition].transform.position,alpha
                    );
            yield return new WaitForFixedUpdate();
        }

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
