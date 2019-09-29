using System;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework
 {
     public abstract class BaseMasterController : MonoBehaviour, IMasterController
     {
         private static IMasterController instance;

         protected virtual void Start()
         {
             instance = this;
         }

         public static BaseMasterController Instance
         {
             get
             {
                 return (BaseMasterController) instance;
             }
         }

         public void OnLevelStarted(ILevelController controller)
         {
             Debug.Log("Level controller called back: " + controller);
         }
     }
 }
 