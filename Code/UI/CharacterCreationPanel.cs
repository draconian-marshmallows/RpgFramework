using System;
using DraconianMarshmallows.RpgFramework.Structures;
using DraconianMarshmallows.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public class CharacterCreationPanel : UIBehavior
    {
        public Action<Character> OnCreateCharacter;

        [SerializeField] private TextInput nameInput;
        [SerializeField] private Dropdown classDropdown;
        [SerializeField] private ButtonPlus createButton;
        private int classSelectionIndex;

        protected override void Start()
        {
            classDropdown.onValueChanged.AddListener(onClassValueChanged);
            createButton.onClick.AddListener(onCreateClicked);
        }

        private void onClassValueChanged(int selectionIndex)
        {
            classSelectionIndex = selectionIndex;
        }

        private void onCreateClicked()
        {
            // TODO:: Add validation. 
            var player = new Character {Name = nameInput.text, ChosenClass = getChosenClass()};
            OnCreateCharacter(player);
        }

        private Character.Class getChosenClass()
        {
            switch (classSelectionIndex)
            {
                case 1: return Character.Class.MAGE;
                case 2: return Character.Class.WARRIOR;
                default:
                {
                    Debug.LogWarning("TODO:: tell player to choose a class for the new character");
                    throw new UnityException("Player should choose a class...");
                }
            }
        }
    }
}
