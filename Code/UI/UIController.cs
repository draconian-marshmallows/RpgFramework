using System.Collections;
using System.Collections.Generic;

using DraconianMarshmallows.RpgFramework.Structures;
using DraconianMarshmallows.UI;

using Newtonsoft.Json;

using UnityEngine;

public class UIController : ParentUIController
{
    [SerializeField] private CharacterCreationPanel characterCreationPanel;

    override protected void Start()
    {
        characterCreationPanel.OnCreateCharacter = onCreateCharacter;
    }

    private void onCreateCharacter(Character character)
    {
        Debug.Log("Creating character: " + JsonConvert.SerializeObject(character));
        Debug.LogWarning("TODO:: ACTUALLY CREATE CHARACTER AND START GAME !!!");
    }
}
