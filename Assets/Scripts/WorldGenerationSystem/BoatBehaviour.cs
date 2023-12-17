using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject StartPosition;
    [SerializeField] private GameObject EndPosition;

    private bool MovingTowardsEnd;
    public float Velocidad = 2;

    void FixedUpdate()
    {
        Vector2 endposition = MovingTowardsEnd ? EndPosition.transform.position : StartPosition.transform.position;
        float direction = endposition.x < transform.position.x ? transform.position.x + -Velocidad * Time.deltaTime : transform.position.x + Velocidad * Time.deltaTime;

        transform.position = new Vector2(direction, transform.position.y);
        if(Vector2.Distance(transform.position, endposition) < 2f) { MovingTowardsEnd = !MovingTowardsEnd; }

        
    }
}
