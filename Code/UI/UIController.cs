﻿using System.Collections;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Code.UI;
using DraconianMarshmallows.RpgFramework.Structures;
using DraconianMarshmallows.UI;

using Newtonsoft.Json;

using UnityEngine;

public class UIController : ParentUIController
{
    [SerializeField] private TitleScreen titleScreenUI;
    [SerializeField] private CharacterCreationPanel characterCreationPanel;
    [SerializeField] private InPlayUI inPlayUI;

    override protected void Start()
    {
        // characterCreationPanel.OnCreateCharacter = onCreateCharacter;
    }

    public void DisplayInPlayUI()
    {
        titleScreenUI.SetActive(false);
        characterCreationPanel.SetActive(false);
        inPlayUI.SetActive(true);
    }
}
