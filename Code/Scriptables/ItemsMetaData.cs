using System;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Structures.Inventory;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.Scriptables
{
    [CreateAssetMenu(menuName="DraconianMarshmallows/RpgFramework/ItemsMetaData", fileName="ItemsMetaData")]
    public class ItemsMetaData : BaseItemsMetaData
    {
        [SerializeField] private EnumToMeta[] enumToMeta;
        
//        [SerializeField] private BaseItemMeta shotGlass;
//        [SerializeField] private BaseItemMeta squeakyRubberHamburger;

        private Dictionary<Enum, BaseItemMeta> enumToMetaMap;

        private void OnEnable()
        {
            Debug.Log("on enable !!!");
            
            enumToMetaMap = new Dictionary<Enum, BaseItemMeta>();
            foreach (var meta in enumToMeta)
            {
                enumToMetaMap.Add(meta.type, meta.itemMeta);
            }
        }

        protected override Dictionary<Enum, BaseItemMeta> getEnumToMetaMap()
        {
            return enumToMetaMap;
        }
        
        [Serializable] private class EnumToMeta
        {
            public Item.Type type;
            public ItemMeta itemMeta;
        }
    }
}