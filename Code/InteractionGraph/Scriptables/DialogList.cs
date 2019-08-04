using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.InteractionGraph.Scriptables
{
    public class DialogList : ScriptableObject
    {
        [SerializeField] private DialogItem[] items;

        public DialogItem[] Items => items;
    }
}
