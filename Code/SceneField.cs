using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace DraconianMarshmallows.RpgFramework.Editor
{
    [System.Serializable] public class SceneField
    {
        [SerializeField] private Object sceneAsset;
        [SerializeField] private string sceneName;

        private string SceneName => sceneName;

        // Makes it work with the existing Unity methods (LoadLevel/LoadScene). 
        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }
    }
    
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);
            var sceneAsset = property.FindPropertyRelative("sceneAsset");
            var sceneName = property.FindPropertyRelative("sceneName");
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (sceneAsset != null)
            {
                sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue,
                    typeof(SceneAsset), false);
                
                sceneName.stringValue = sceneAsset.objectReferenceValue != null ? 
                    AssetDatabase.GetAssetPath(sceneAsset.objectReferenceValue as SceneAsset) : null;
            }
            EditorGUI.EndProperty();
        }
    }
#endif
}
