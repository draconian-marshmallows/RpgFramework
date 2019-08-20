using DraconianMarshmallows.RpgFramework.StateMachine;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Characters
{
    public class CharacterStateTransitionListener : StateTransitionListener
    {
        [SerializeField] public CharacterAnimationState State;
    }
}
