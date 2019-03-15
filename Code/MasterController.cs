using System;
using System.Collections;
using System.Collections.Generic;

using DraconianMarshmallows.RpgFramework;
using DraconianMarshmallows.RpgFramework.Structures;
using Newtonsoft.Json;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private CharacterCreationPanel characterCreationPanel;

    protected virtual void Start()
    {
        characterCreationPanel.OnCreateCharacter = onCreateCharacter;
    }

    private void onCreateCharacter(Character character)
    {
        Debug.Log("Creating character: " + JsonConvert.SerializeObject(character));
        Debug.LogWarning("TODO:: ACTUALLY CREATE CHARACTER AND START GAME !!!");

        dataManager.SavePlayer(character);
    }
}
