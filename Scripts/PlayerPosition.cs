using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPosition.position;
    }
}
