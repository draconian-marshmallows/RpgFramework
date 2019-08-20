using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.StateMachine
{
    public class StateTransitionListener : StateMachineBehaviour
    {
        public delegate void StateTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);

//        public int ID;
        public event StateTransition OnStateEnterEvents;
        public event StateTransition OnStateExitEvents;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            OnStateEnterEvents?.Invoke(animator, stateInfo, layerIndex);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            OnStateExitEvents?.Invoke(animator, stateInfo, layerIndex);
        }
    }
}
