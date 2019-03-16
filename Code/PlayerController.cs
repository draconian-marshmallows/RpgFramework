using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform tmpDestination;

    private RaycastHit hitPoint;

    private void Start()
    {
        // navMeshAgent.SetDestination(tmpDestination.position);
    }

    private void Update()
    {
        if ( ! Input.GetMouseButtonDown(0))
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint, 2000))
        {
            navMeshAgent.SetDestination(hitPoint.point);
        }
    }
}
