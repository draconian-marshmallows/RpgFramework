using System;
using System.Collections;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Structures;
using DraconianMarshmallows.UI;

using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationPanel : UIBehavior
{
    public Action<Character> OnCreateCharacter;

    [SerializeField] private TextInput nameInput;
    [SerializeField] private Dropdown classDropdown;
    [SerializeField] private ButtonPlus createButton;
    private int classSelctionIndex = 0;

    override protected void Start()
    {
        classDropdown.onValueChanged.AddListener(onClassValueChanged);
        createButton.onClick.AddListener(onCreateClicked);
    }

    private void onClassValueChanged(int selectionIndex)
    {
        classSelctionIndex = selectionIndex;
    }

    private void onCreateClicked()
    {
        // TODO:: Add validation. 
        var player = new Character();
        player.Name = nameInput.text;
        player.ChosenClass = getChosenClass();
        OnCreateCharacter(player);
    }

    private Character.Class getChosenClass()
    {
        switch (classSelctionIndex)
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
