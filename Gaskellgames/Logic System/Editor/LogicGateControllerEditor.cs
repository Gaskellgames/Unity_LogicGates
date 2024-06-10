#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// Code created by Gaskellgames: https://github.com/Gaskellgames
/// </summary>

namespace Gaskellgames.LogicSystem
{
    [CustomEditor(typeof(LogicGateController)), CanEditMultipleObjects]
    public class LogicGateControllerEditor : Editor
    {
        #region Serialized Properties / OnEnable
        
        private SerializedProperty logicGate;
        private SerializedProperty OnEvent;
        private SerializedProperty OffEvent;
        private SerializedProperty info;

        private int selectedTab = 0;
        private string[] tabs = new[] { "Settings", "Events", "Debug" };
        
        private readonly int SettingsTab = 0;
        private readonly int EventsTab = 1;
        private readonly int DebugTab = 2;

        private void OnEnable()
        {
            logicGate = serializedObject.FindProperty("logicGate");
            OnEvent = serializedObject.FindProperty("OnEvent");
            OffEvent = serializedObject.FindProperty("OffEvent");
            info = serializedObject.FindProperty("info");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------
        
        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            LogicGateController logicGateController = (LogicGateController)target;
            serializedObject.Update();

            // draw banner if turned on in Gaskellgames settings
            string textureFilepath = "Assets/Gaskellgames/Logic System/Editor/Icons/InspectorBanner_LogicSystem.png";
            
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath(textureFilepath, typeof(Texture));
            float imageWidth = EditorGUIUtility.currentViewWidth;
            float imageHeight = imageWidth * banner.height / banner.width;
            Rect rect = GUILayoutUtility.GetRect(imageWidth, imageHeight);
            
            // adjust rect to account for offsets in inspectors
            float paddingTop = -4;
            float paddingLeft = -18;
            float paddingRight = -4;
            float xMin = rect.x + paddingLeft;
            float yMin = rect.y + paddingTop;
            float width = rect.width - (paddingLeft + paddingRight);
            float height = rect.height;
            rect = new Rect(xMin, yMin, width, height);
            
            // draw banner
            GUI.DrawTexture(rect, banner, ScaleMode.ScaleToFit);
            
            // custom inspector
            selectedTab = GUILayout.Toolbar(selectedTab, tabs);
            EditorGUILayout.Space();
            if (selectedTab == SettingsTab)
            {
                EditorGUILayout.PropertyField(logicGate);
                EditorGUILayout.Space();
                if (logicGateController.WarningType == LogicGateController.logicGates.BUFFER)
                {
                    EditorGUILayout.HelpBox("BUFFER: If the input is true, then the output is true. If the input is false, then the output is false.", MessageType.Info);
                    EditorGUILayout.HelpBox("Output based on a single input (Input1)", MessageType.Warning);
                }
                else if (logicGateController.WarningType == LogicGateController.logicGates.AND)
                {
                    EditorGUILayout.HelpBox("AND: The output is true when both inputs are true. Otherwise, the output is false.", MessageType.Info);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.OR)
                {
                    EditorGUILayout.HelpBox("OR: The output is true if either or both of the inputs are true. If both inputs are false, then the output is false.", MessageType.Info);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.XOR)
                {
                    EditorGUILayout.HelpBox("XOR (exclusive-OR): The output is true if either, but not both, of the inputs are true. The output is false if both inputs are false or if both inputs are true.", MessageType.Info);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.NOT)
                {
                    EditorGUILayout.HelpBox("NOT: If the input is true, then the output is false. If the input is false, then the output is true.", MessageType.Info);
                    EditorGUILayout.HelpBox("Output based on a single input (Input1)", MessageType.Warning);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.NAND)
                {
                    EditorGUILayout.HelpBox("NAND (not-AND): The output is false if both inputs are true. Otherwise, the output is true.", MessageType.Info);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.NOR)
                {
                    EditorGUILayout.HelpBox("NOR (not-OR): output is true if both inputs are false. Otherwise, the output is false.", MessageType.Info);
                }
                else if(logicGateController.WarningType == LogicGateController.logicGates.XNOR)
                {
                    EditorGUILayout.HelpBox("XNOR (exclusive-NOR): output is true if the inputs are the same, and false if the inputs are different", MessageType.Info);
                }
            }
            else if (selectedTab == EventsTab)
            {
                EditorGUILayout.PropertyField(OnEvent);
                EditorGUILayout.PropertyField(OffEvent);
            }
            else if (selectedTab == DebugTab)
            {
                GUI.enabled = false;
                EditorGUILayout.PropertyField(info);
                GUI.enabled = true;
            }

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}

#endif