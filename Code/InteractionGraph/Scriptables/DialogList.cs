using System;
using System.Linq;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.InteractionGraph.Scriptables
{
    [CreateAssetMenu(menuName = "DraconianMarshmallows/InteractionGraph/DialogList", fileName = "DialogList")]
    [Serializable] public class DialogList : ScriptableObject
    {
        [SerializeField] private DialogItem[] items;

        public DialogItem[] Items => items;

        // TMP:: To be removed later. 
        [Obsolete("This method's only here to plug into the existing NPC behavior, will be replaced later.")]
        public string[] ToArray()
        {
            var i = 0;
            var stringList = new string[items.Length];
            foreach (var item in items)
            {
                stringList[i] = item.Text;
                i++;
            }
            return stringList;
        }
    }
}
