using System;
using System.Collections;
using System.Collections.Generic;

using DraconianMarshmallows.RpgFramework;
using DraconianMarshmallows.RpgFramework.Structures;
using Newtonsoft.Json;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private enum Mode { INITIALIZING, PLAYING }

    [SerializeField] private DataManager dataManager;
    [SerializeField] private UIController uiController;
    [SerializeField] private CharacterCreationPanel characterCreationPanel;

    private Mode currentMode = Mode.INITIALIZING;

    protected virtual void Start()
    {
        characterCreationPanel.OnCreateCharacter = onCreateCharacter;
    }

    private void onCreateCharacter(Character character)
    {
        Debug.Log("Creating character: " + JsonConvert.SerializeObject(character));

        dataManager.SavePlayer(character);
        uiController.DisplayInPlayUI();
        currentMode = Mode.PLAYING;
    }
}
