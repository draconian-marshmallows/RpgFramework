using System;
using DraconianMarshmallows.RpgFramework.Code;
using UnityEngine;

namespace DraconianMarshmallows.RpgFramework
{
    public class LevelController : MonoBehaviour, ILevelController
    {
        [SerializeField] private BasePlayerController playerController;
        
        public static BaseMasterController Instance
        {
            get { return BaseMasterController.Instance; }
        }
        
        protected virtual void Start()
        {
            BaseMasterController masterController = null;
            try {
                masterController = BaseMasterController.Instance;
            }
            catch (Exception e) {
                Debug.LogWarning("MasterController isn't around - probably testing a scene without...");
            }
            if (masterController)
                masterController.OnLevelStarted(this);
            else
                Debug.LogWarning("Master Controller isn't found ... Are you testing a scene ?");
        }

        public BasePlayerController PlayerController
        {
            get
            {
                throw new NotImplementedException("Do IT!");   
            }
        }

        public BasePlayerController GetPlayerController()
        {
            throw new NotImplementedException();
        }
    }
}
