using System.Collections;
using System.Collections.Generic;
using DraconianMarshmallows.RpgFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DraconianMarshmallows.RpgFramework.Examples
{
    public class ExampleMasterController : BaseMasterController
    {
        public enum Level
        {
            LEVEL_1 = 5
        }

        [SerializeField] private Level startLevel;
        
        protected override void Start()
        {
            base.Start();
            loadLevel();
        }

        private void loadLevel()
        {
            SceneManager.LoadScene((int) startLevel, LoadSceneMode.Additive);
        }

//        public static BaseMasterController Instance
//        {
//            get { return BaseMasterController.Instance;  }
//        }
    }
}
