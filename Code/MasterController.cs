﻿using System;
using System.Collections;
using System.Collections.Generic;

using DraconianMarshmallows.RpgFramework;
using DraconianMarshmallows.RpgFramework.Code.UI;
using DraconianMarshmallows.RpgFramework.Structures;
using Newtonsoft.Json;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework
{
    public class MasterController : MonoBehaviour, IMasterController
    {
        public static MasterController Instance { get; private set; }

        private enum Mode { INITIALIZING, PLAYING }
        
        [SerializeField] private DataManager dataManager;
        [SerializeField] private UIController uiController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private CharacterCreationPanel characterCreationPanel;

        private Mode currentMode = Mode.INITIALIZING;

        protected virtual void Awake()
        {
            Instance = this;
        }

        protected virtual void Start()
        {
            // FIX:: This should only be accessed through the main uiController. 
            if (characterCreationPanel) characterCreationPanel.OnCreateCharacter = onCreateCharacter;

            sceneController.LoadStartScene();
        }

        public void OnLevelStarted(ILevelController controller)
        {
            Debug.Log("Level controller called back that it's started: " + controller);
        }

        private void onCreateCharacter(Character character)
        {
            Debug.Log("Creating character: " + JsonConvert.SerializeObject(character));

            dataManager.SavePlayer(character);
            uiController.DisplayInPlayUI();
            currentMode = Mode.PLAYING;
        }
    }
}
