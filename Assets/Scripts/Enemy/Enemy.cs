using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform[] movePoints;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private int _startPosition = 0;
    [SerializeField] private int _endPosition = 1;
    private float _minTargetDistance = 0.01f;
    private Rigidbody2D rb;


    void Start()
    {
        this.transform.position = this.movePoints[0].transform.position;
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        float alpha = 0.0f;
        while (true)
        {
            alpha += Time.fixedDeltaTime * moveSpeed;
            if ((1.0f - alpha) < _minTargetDistance)
            {
                _startPosition++;
                _endPosition++;
                _startPosition %= movePoints.Length;
                _endPosition %= movePoints.Length;
                alpha = 0f;
            }


            this.transform.position = Vector3.Lerp(
                this.movePoints[_startPosition].transform.position,
                this.movePoints[_endPosition].transform.position, alpha
                    );
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //make player die when encouter
        if (other.CompareTag("RedPlayer")|| other.CompareTag("BluePlayer"))
        {
            Time.timeScale = 0;
            GameManager.Instance.ShowGameOverMenu();
        }
       
    }
}
