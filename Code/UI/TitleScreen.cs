using System;
using System.Collections;
using System.Collections.Generic;

using DraconianMarshmallows.UI;

using UnityEngine;

public class TitleScreen : UIBehavior
{
    [SerializeField] private UIBehavior characterCreationPanel;
    [SerializeField] private UIBehavior loadGamePanel;

    [SerializeField] private ButtonPlus startButton;
    [SerializeField] private ButtonPlus loadButton;

    override protected void Start()
    {
        startButton.onClick.AddListener(onClickStart);
        loadButton.onClick.AddListener(onClickLoad);
    }

    private void onClickStart()
    {
        SetActive(false);
        characterCreationPanel.SetActive(true);
    }

    private void onClickLoad()
    {
        SetActive(false);
        loadGamePanel.SetActive(true);
    }
}
