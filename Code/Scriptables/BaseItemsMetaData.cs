using System;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Code.Structures.Inventory;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.Scriptables
{
    public abstract class BaseItemsMetaData : ScriptableObject
    {
        public virtual BaseItemMeta getMetaForItem(BaseItem item)
        {
            return getEnumToMetaMap()[item.getType()];
        }

        protected abstract Dictionary<Enum, BaseItemMeta> getEnumToMetaMap();
    }
}