﻿using System;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Code.Scriptables;
using DraconianMarshmallows.RpgFramework.Code.Structures.Inventory;
using DraconianMarshmallows.RpgFramework.Structures.Inventory;
using DraconianMarshmallows.UI;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.UI
{
    public abstract class BaseInventoryPanel : UIBehavior
    {
        [SerializeField] protected BaseItemsMetaData itemsMetaData;
        [SerializeField] protected BaseInventoryButton itemButtonPrefab;
        [SerializeField] protected Transform inventoryContainer; 

        protected List<Item> items; 

//        [SerializeField] private BaseItemsMetaData itemsMetaData;

//        [Serializable] public abstract class BaseItemsMetaData
//        {
//            protected abstract ItemMeta getMetaForItem(BaseItem);
//        }
    }
}
