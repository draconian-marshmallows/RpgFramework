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
        // characterCreationPanel.OnCreateCharacter = onCreateCharacter;
    }
}
