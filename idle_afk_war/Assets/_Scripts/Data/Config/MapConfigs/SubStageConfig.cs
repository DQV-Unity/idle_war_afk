using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

namespace _Scripts.Data.Config
{
    [CreateAssetMenu(fileName = "SubStageConfig", menuName = "Config/Map/Stage/SubStageConfig")]
    public class SubStageConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private List<WaveConfig> _waveConfigs;

        public int ID => _id;
        public List<WaveConfig> WaveConfigs => _waveConfigs;
    }

    [Serializable]
    public class WaveConfig
    {
        [SerializeField] private int _enemyID;
        [SerializeField] private int _enemyAmount;

        public int EnemyID => _enemyID;

        public int EnemyAmount => _enemyAmount;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SubStageConfig))]
    public class SubStageConfigEditor : Editor
    {
        private SerializedProperty _waveConfigs;
        private ReorderableList _waveList;

        private void OnEnable()
        {
            _waveConfigs = serializedObject.FindProperty("_waveConfigs");

            _waveList = new ReorderableList(
                serializedObject,
                _waveConfigs,
                draggable: true,
                displayHeader: true,
                displayAddButton: true,
                displayRemoveButton: true
            );

            _waveList.drawHeaderCallback = rect => { EditorGUI.LabelField(rect, "Wave Configs"); };

            _waveList.elementHeightCallback = index =>
            {
                SerializedProperty element = _waveConfigs.GetArrayElementAtIndex(index);
                return EditorGUI.GetPropertyHeight(element, true) + 6f;
            };

            _waveList.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                SerializedProperty element = _waveConfigs.GetArrayElementAtIndex(index);

                rect.y += 3f;
                rect.height = EditorGUI.GetPropertyHeight(element, true);

                string label = index == _waveConfigs.arraySize - 1
                    ? "Final Wave"
                    : $"Wave {index + 1}";

                Rect propertyRect = new Rect(
                    rect.x + 12f,
                    rect.y,
                    rect.width - 12f,
                    rect.height
                );

                EditorGUI.PropertyField(propertyRect, element, new GUIContent(label), true);
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            SerializedProperty idProp = serializedObject.FindProperty("_id");
            EditorGUILayout.PropertyField(idProp, new GUIContent("ID"));
            EditorGUILayout.Space(4f);
            
            _waveList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}