﻿using System;
using System.Collections;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework.Code.Structures.Inventory;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework.Structures.Inventory
{
    public class Item : BaseItem
    {
        public enum Type { BEER_MUG, SHOT_GLASS, BAR_STOOL }

        public Item(Enum type) : base(type) { }
        
//        public override Enum getType()

//        {

//            return Type.SHOT_GLASS;

//        }
    }
}
