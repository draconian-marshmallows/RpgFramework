﻿using System;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Code.Scriptables;
using DraconianMarshmallows.RpgFramework.Code.Structures.Inventory;
using DraconianMarshmallows.RpgFramework.Structures.Inventory;
using JetBrains.Annotations;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public class InventoryPanel : BaseInventoryPanel
    {
        private ItemMeta itemMeta; 
        
        protected override void Start()
        {
            base.Start();
            // HACK:: DEBUG DATA: 
            items = new List<Item> {new Item(Item.Type.BEER_MUG)};

            var meta = itemsMetaData;
//            var typeMap = itemsMetaData.GetType()

            foreach (var item in items)
            {
                itemMeta = meta.getMetaForItem(item) as ItemMeta;
                
                var button = Instantiate<BaseInventoryButton>(itemButtonPrefab, inventoryContainer, true);
                if (itemMeta == null) continue;
                
                button.Icon = itemMeta.Icon;
                button.Label = itemMeta.Label;
            }
        }
    }
}
