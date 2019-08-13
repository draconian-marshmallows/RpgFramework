using System;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace DraconianMarshmallows.RpgFramework.Characters.ThirdPerson
{
    public class AICharacterController : MonoBehaviour
    {
        private Vector3 targetPosition { get; set; }

//        private const string HIT = "hit";
        private const string ATTACK1 = "Fire1";
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const float MIN_DIRECTIONAL_VALUE = .1f;
        private const float DIRECTION_MULTIPLIER = 5f;
        
        private static readonly int START_ATTACK_1 = Animator.StringToHash("StartAttack1");

//        [SerializeField] private AnimationClip attack1Clip;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform directionIndicator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private ThirdPersonCharacter character;

        private float horizontalAxis;
        private float verticalAxis;
        private RaycastHit hitPoint;

        private void Start()
        {
            // var attack1HitEvent = new AnimationEvent();
            // attack1HitEvent.functionName = "onAttack1Hit";
            // attack1Clip.AddEvent(attack1HitEvent);
            // attack1Clip.events += onAttack1Hit;

	        agent.updateRotation = false;
	        agent.updatePosition = true;
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

        public void Hit()
        {
            Debug.Log("HIT METHOD CALLED !!!");
            animator.SetBool(START_ATTACK_1, false);
        }

        // private void onAttack1Hit()
        // {
        //     Debug.Log("WE'RE MAKING A HIT !!!!!!!!!!!!!!!!!!!!");
        //     animator.SetBool(ATTACK1_START, false);
        // }

        private void checkForCombatInput()
        {
            // TODO:: Set up attack-1 input that doesn't clash with LMB. 
            // TODO:: Switch off attack flag at end of attack animation. 
//            if (Input.GetButtonDown(ATTACK1))
//            {
////                Debug.Log("stuff is dying !!!!!!!"); 
//                animator.SetBool(START_ATTACK_1, true);
//            }
        }

        private bool checkForDirectionalControl()
        {
            horizontalAxis = Input.GetAxis(HORIZONTAL);
            verticalAxis = Input.GetAxis(VERTICAL);

            if (Mathf.Abs(horizontalAxis) < MIN_DIRECTIONAL_VALUE
                && Mathf.Abs(verticalAxis) < MIN_DIRECTIONAL_VALUE)
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
