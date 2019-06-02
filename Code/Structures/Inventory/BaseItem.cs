using System;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Code.Structures.Inventory
{
    public abstract class BaseItem
    {
        private readonly Enum type;

        protected BaseItem(Enum type)
        {
            this.type = type;
        }
        
        public virtual Enum getType()
        {
            return type;
        }
    }
}