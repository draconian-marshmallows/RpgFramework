using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace DraconianMarshmallows.RpgFramework.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }  // the navmesh agent required for the path finding.
        public ThirdPersonCharacter character { get; private set; }     // the character we are controlling.
        public Vector3 targetPosition { get; set; }



        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const float MIN_DIRECITONAL_VALUE = .1f;
        private const float DIRECTION_MULTIPLIER = 5f;

        // [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Transform directionIndicator;

        private float horizontalAxis = 0;
        private float verticalAxis = 0;
        private RaycastHit hitPoint;

        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        private void Update()
        {
            if (targetPosition != null)
                agent.SetDestination(targetPosition);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if (checkForDirectionalControl())
                return;

            checkForClick();
        }

        private bool checkForDirectionalControl()
        {
            horizontalAxis = Input.GetAxis(HORIZONTAL);
            verticalAxis = Input.GetAxis(VERTICAL);

            if (Mathf.Abs(horizontalAxis) < MIN_DIRECITONAL_VALUE
                && Mathf.Abs(verticalAxis) < MIN_DIRECITONAL_VALUE)
                return false;

            var localPosition = directionIndicator.localPosition;
            localPosition.x = horizontalAxis * DIRECTION_MULTIPLIER;
            localPosition.z = verticalAxis * DIRECTION_MULTIPLIER;
            directionIndicator.localPosition = localPosition;

            // navMeshAgent.SetDestination(directionIndicator.position);
            targetPosition = directionIndicator.position;
            return true;
        }

        private void checkForClick()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint, 2000))
                targetPosition = hitPoint.point;


            // navMeshAgent.SetDestination(hitPoint.point);
        }
    }
}
