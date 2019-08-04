using System;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.InteractionGraph.Scriptables
{
    /// <summary>
    /// Extendable class for information for each piece of dialog.
    /// Currently only stores the dialog-string to display.
    /// Further usage is to store keys to localized strings, references to audio & files used for lip-sync. 
    /// </summary>
    [CreateAssetMenu(menuName = "DraconianMarshmallows/InteractionGraph/DialogItem", fileName = "DialogItem")]
    [Serializable] public class DialogItem : ScriptableObject
    {
        public string Text;
    }
}
