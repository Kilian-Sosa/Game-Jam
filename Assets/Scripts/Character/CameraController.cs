using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float xMin, xMax;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
            transform.position.y, transform.position.z);
    }
}

