using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public Transform currentTarget;
    private NavMeshAgent _agent;
    private Animator _animator;
    public int i, j, k = 1;
    public int reverseWay = 0;
    private bool coinThrowed = false;
    private Vector3 coinPosition;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                currentTarget = wayPoints[0];
                _agent.SetDestination(currentTarget.position);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints.Count > 1 && coinThrowed == false)
        {
            if(k == 1)
            {
                _animator.SetBool("Walk", true);
                k = 0;
            }
                
            float distance = Vector3.Distance(transform.position, currentTarget.position);

            if (distance < 1.0f && wayPoints.Count > i && reverseWay == 0)
            {
                currentTarget = wayPoints[i];
                _agent.SetDestination(currentTarget.position);
                i++;
            }
            if (wayPoints.Count == i && distance < 0.2f && j == 1)
            {
                j = 0;
                StartCoroutine(guardDelay());
            }
            if (i == -1 && distance < 1.0f && j == 1)
            {
                j = 0;
                StartCoroutine(guardDelay());
            }
            if (distance < 1.0f && i >= 0 && reverseWay == 1)
            {
                currentTarget = wayPoints[i];
                _agent.SetDestination(currentTarget.position);
                i--;
            }
        }
        else if (wayPoints.Count == 1 && k == 1)
        {
            _animator.SetBool("Walk", true);
            float distance = Vector3.Distance(transform.position, currentTarget.position);
            if (distance < 0.2f)
            {
                _animator.SetBool("Walk", false);
                k = 0;
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPosition);

            if(distance < 4.0f)
            {
                _animator.SetBool("Walk", false);
                _agent.isStopped = true;
            }
        }
        
    }

    IEnumerator guardDelay()
    {
        _animator.SetBool("Walk", false);

        yield return new WaitForSeconds(2.0f);

        if (reverseWay == 0)
        {
            reverseWay = 1;
            i--;
            j = 1;
            _animator.SetBool("Walk", true);
        }
        else
        {
            reverseWay = 0;
            i++;
            j = 1;
            _animator.SetBool("Walk", true);
        }
    }

    public void goToCoin(Vector3 coinPos)
    {
        coinThrowed = true;
        coinPosition = coinPos;
        _animator.SetBool("Walk", true);
        _agent.SetDestination(coinPos);
    }
}
