using System;
using System.Collections;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework;
using DraconianMarshmallows.RpgFramework.Code;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BasePlayerController
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL   = "Vertical";

    private const float MIN_DIRECTIONAL_VALUE   = .1f;
    private const float DIRECTION_MULTIPLIER    = 5f;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform directionIndicator;

    private float horizontalAxis;
    private float verticalAxis;
    private RaycastHit hitPoint;

    private void Update() // TODO:: plug in UpdateManager. 
    {
        if (checkForDirectionalControl())
            return;

        checkForClick();
    }

    private bool checkForDirectionalControl()
    {
        horizontalAxis  = Input.GetAxis(HORIZONTAL);
        verticalAxis    = Input.GetAxis(VERTICAL);

        if (Mathf.Abs(horizontalAxis) < MIN_DIRECTIONAL_VALUE 
            && Mathf.Abs(verticalAxis) < MIN_DIRECTIONAL_VALUE)
            return false;

        var localPosition = directionIndicator.localPosition;
        localPosition.x = horizontalAxis * DIRECTION_MULTIPLIER;
        localPosition.z = verticalAxis * DIRECTION_MULTIPLIER;
        directionIndicator.localPosition = localPosition;

        navMeshAgent.SetDestination(directionIndicator.position);
        return true;
    }

    private void checkForClick()
    {
        if ( ! Input.GetMouseButtonDown(0))
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint, 2000))
            navMeshAgent.SetDestination(hitPoint.point);
    }
}
