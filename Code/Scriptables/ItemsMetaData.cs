using System;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Structures.Inventory;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.Scriptables
{
    [CreateAssetMenu(menuName="DraconianMarshmallows/RpgFramework/ItemsMetaData", fileName="ItemsMetaData")]
    public class ItemsMetaData : BaseItemsMetaData
    {
        [SerializeField] private EnumToMeta[] enumToMetas;
        
//        [SerializeField] private BaseItemMeta shotGlass;
//        [SerializeField] private BaseItemMeta squeakyRubberHamburger;

        private Dictionary<Enum, BaseItemMeta> enumToMetaMap;

        private void OnEnable()
        {
            enumToMetaMap = new Dictionary<Enum, BaseItemMeta>();
            foreach (var enumToMeta in enumToMetas)
            {
                enumToMetaMap.Add(enumToMeta.type, enumToMeta.itemMeta);
            }
            
//            {
//                {Item.Type.SHOT_GLASS, shotGlass}
//            };
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