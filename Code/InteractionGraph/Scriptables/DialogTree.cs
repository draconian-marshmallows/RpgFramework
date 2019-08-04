using System;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.InteractionGraph.Scriptables
{
    [CreateAssetMenu(menuName = "DraconianMarshmallows/InteractionGraph/DialogTree", fileName = "DialogTree")]
    [Serializable] public class DialogTree : ScriptableObject
    {
        // TODO:: Add tree/graph. 
        // TMP:: Right now this is just built to use a dialog list, we'll want to expand this to branching dialog. 
        [SerializeField] private DialogList dialogList;

        // TMP:: To be removed later. 
        [Obsolete("This method's only here to plug into the existing NPC behavior, will be replaced later.")]
        public string[] getArray()
        {
            return dialogList.ToArray();
        }
    }
}