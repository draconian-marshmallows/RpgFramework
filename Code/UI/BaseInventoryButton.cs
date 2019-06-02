﻿using UnityEditor.Experimental.U2D;
using UnityEngine;
using UnityEngine.UI;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public class BaseInventoryButton : MonoBehaviour
    {
        [HideInInspector] public Sprite icon;
        public string Label { set => labelText.text = value; }
        public Sprite Icon { set => iconImage.sprite = value; }

        [SerializeField] private Image iconImage;
        [SerializeField] private Text labelText;
    }
}
