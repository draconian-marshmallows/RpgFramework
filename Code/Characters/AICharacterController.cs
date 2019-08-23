using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace DraconianMarshmallows.RpgFramework.Characters.ThirdPerson
{
    public class AICharacterController : MonoBehaviour
    {
        private const string ATTACK1 = "Fire1";
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const float MIN_DIRECTIONAL_VALUE = .1f;
        private const float DIRECTION_MULTIPLIER = 5f;
        
        private static readonly int Attack1Trigger = Animator.StringToHash("Attack1Trigger");
        private int attack1 = -1;

        [SerializeField] private Animator animator;
        [SerializeField] private Transform directionIndicator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private ThirdPersonCharacter character;

        private float horizontalAxis;
        private float verticalAxis;
        private RaycastHit hitPoint;
        private Vector3 targetPosition;
        private Vector3 lastTargetPosition;
        private Camera mainCamera;
        private bool isCameraNotNull;
        private Dictionary<CharacterAnimationState, CharacterStateTransitionListener> animatorStates;

        private void Start()
        {
            attack1 = Animator.StringToHash("Attack1Trigger");
            mainCamera = Camera.main;
            isCameraNotNull = mainCamera != null;

            Debug.Log("attack 1: " + attack1);
            Debug.Log(mainCamera);

            animatorStates = animator.GetBehaviours<CharacterStateTransitionListener>()
                .ToDictionary(listener => listener.State);

            var stateTransitionListener = animatorStates[CharacterAnimationState.ATTACK_1];
            stateTransitionListener.OnStateEnterEvents += OnAttack1StateEnter;
            stateTransitionListener.OnStateExitEvents += OnAttack1StateExit;

            agent.updateRotation = false;
	        agent.updatePosition = true;
            lastTargetPosition = targetPosition;
        }

        private void Update()
        {
            checkForCombatInput();

            if (targetPosition != lastTargetPosition)
            {
//                Debug.Log("setting destination !!!");
                agent.SetDestination(targetPosition);
                lastTargetPosition = targetPosition;
            }

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if (checkForDirectionalControl())
                return;

            checkForClick();
        }

        private void checkForCombatInput()
        {
            // TODO:: Set up attack-1 input that doesn't clash with LMB. 
            if (Input.GetButtonDown(ATTACK1))
            {
                animator.SetTrigger(Attack1Trigger);
            }
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
            
//            Debug.Log("Directional controls setting target !!!");
            targetPosition = directionIndicator.position;
            return true;
        }

        private void checkForClick()
        {
            if (!Input.GetMouseButtonDown(0))
                return;

            if (isCameraNotNull && 
                Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitPoint, 2000))
                targetPosition = hitPoint.point;
        }

        private void OnAttack1StateEnter(Animator ignore, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Character started attack !!!");
            agent.stoppingDistance = 100f;
        }

        private void OnAttack1StateExit(Animator ignore, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Character finished attack !!!");
            agent.stoppingDistance = .2f;
        }
    }
}
