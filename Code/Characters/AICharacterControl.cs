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

        private const string HIT = "hit";
        private const string ATTACK1 = "Fire1";
        private const string ATTACK1_START = "StartAttack1";
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const float MIN_DIRECITONAL_VALUE = .1f;
        private const float DIRECTION_MULTIPLIER = 5f;

        // [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationClip attack1Clip;
        [SerializeField] private Transform directionIndicator;

        private float horizontalAxis = 0;
        private float verticalAxis = 0;
        private RaycastHit hitPoint;

        private void Start()
        {
            // var attack1HitEvent = new AnimationEvent();
            // attack1HitEvent.functionName = "onAttack1Hit";
            // attack1Clip.AddEvent(attack1HitEvent);
            // attack1Clip.events += onAttack1Hit;

            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        public void Hit()
        {
            Debug.Log("HIT METHOD CALLED !!!");
            animator.SetBool(ATTACK1_START, false);
        }

        private void Update()
        {
            checkForCombatInput();

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

        // private void onAttack1Hit()
        // {
        //     Debug.Log("WE'RE MAKING A HIT !!!!!!!!!!!!!!!!!!!!");
        //     animator.SetBool(ATTACK1_START, false);
        // }

        private void checkForCombatInput()
        {
            if (Input.GetButtonDown(ATTACK1))
            {
                Debug.Log("stuff is dying !!!!!!!"); 

                animator.SetBool(ATTACK1_START, true);
            }
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
            
            targetPosition = directionIndicator.position;
            return true;
        }

        private void checkForClick()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint, 2000))
                targetPosition = hitPoint.point;
        }
    }
}
