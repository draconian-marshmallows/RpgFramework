using System;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.InteractionGraph.Scriptables
{
    public abstract class BaseInteraction : ScriptableObject
    {
        public BaseInteraction NextInteraction;
        public Action OnEnd;
        
        public virtual void Start() { }
    }
}
