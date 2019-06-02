﻿using DraconianMarshmallows.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public class InPlayUI : UIBehavior
    {
        [SerializeField] private UIBehavior inventoryPanel;
        [SerializeField] private Button openInventoryButton;

        protected override void Start()
        {
            base.Start();
            openInventoryButton.onClick.AddListener(onClickOpenInventory);
        }

        private void onClickOpenInventory()
        {   
            inventoryPanel.SetActive(true);
        }
    }
}
