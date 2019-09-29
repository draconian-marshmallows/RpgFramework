using UnityEngine;
using DraconianMarshmallows.RpgFramework.Editor;

namespace DraconianMarshmallows.RpgFramework
{
    [CreateAssetMenu(menuName = "DraconianMarshmallows/RpgFramework/SceneController", fileName = "SceneController")]
    public class SceneController : ScriptableObject
    {
        [SerializeField] private SceneField startingScene;
        #if UNITY_EDITOR
        [Header("Debug Settings")]
        [Tooltip("Tells Scene Manager not to load a scene, as you've already loaded the scene you want to test.")]
        [SerializeField] private bool testingSceneLoadedInEditor = true;
        [SerializeField] private SceneField testScene;
        #endif
        public void LoadStartScene()
        {
            #if UNITY_EDITOR
            if (testingSceneLoadedInEditor)
                return;

            if (string.IsNullOrEmpty(testScene))
                Debug.LogWarning("Test scene reference isn't set. Were you testing a scene?");
            else
            {
                handleTestScene();
                return;
            }
            #endif
            loadStartScene();
        }

        private void loadStartScene()
        {
            throw new System.NotImplementedException();
        }

        #if UNITY_EDITOR
        private void handleTestScene()
        {
            Debug.LogWarning("TODO:: handle test scene: " + testScene);
            throw new System.NotImplementedException();
        }
        #endif
    }
}