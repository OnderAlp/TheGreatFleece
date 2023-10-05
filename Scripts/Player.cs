using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;

    private NavMeshAgent _agent;
    Animator _animator;
    RaycastHit hitInfo;

    float distance;
    private bool coinThrow = true;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //cast a ray from mouse position
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //debug the floor position hit
                Debug.Log("Hit: " + hitInfo.point);

                _agent.SetDestination(hitInfo.point);

                _animator.SetBool("Walk", true);

                //create object at floor position
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hitInfo.point;
            }

        }
        distance = Vector3.Distance(transform.position, hitInfo.point);
        if (distance < 1)
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && coinThrow)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);

                coinThrow = false;
                _animator.SetTrigger("coinThrow");
                SendAIToCoinSpot(hitInfo.point);
            }
            
        }
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach(var guard in guards)
        {
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            currentGuard.goToCoin(coinPos);
        }
    }
}
