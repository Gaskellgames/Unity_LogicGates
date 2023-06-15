using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

[CustomEditor(typeof(LogicGateController))] [CanEditMultipleObjects]
public class EditorLogicGateController : Editor
{
    public override void OnInspectorGUI()
    {
        // get & update references
        LogicGateController logicGateController = (LogicGateController)target;
        serializedObject.Update();

        // draw default inspector
        base.OnInspectorGUI();

        // custom inspector: Warning message
        GUILayout.Space(10);
        if (logicGateController.warningType == "BUFFER")
        {
            EditorGUILayout.HelpBox("BUFFER: If the input is true, then the output is true. If the input is false, then the output is false.", MessageType.Info);
            EditorGUILayout.HelpBox("Output based on a single input (Input1)", MessageType.Warning);
        }
        else if (logicGateController.warningType == "AND")
        {
            EditorGUILayout.HelpBox("AND: The output is true when both inputs are true. Otherwise, the output is false.", MessageType.Info);
        }
        else if(logicGateController.warningType == "OR")
        {
            EditorGUILayout.HelpBox("OR: The output is true if either or both of the inputs are true. If both inputs are false, then the output is false.", MessageType.Info);
        }
        else if(logicGateController.warningType == "XOR")
        {
            EditorGUILayout.HelpBox("XOR (exclusive-OR): The output is true if either, but not both, of the inputs are true. The output is false if both inputs are false or if both inputs are true.", MessageType.Info);
        }
        else if(logicGateController.warningType == "NOT")
        {
            EditorGUILayout.HelpBox("NOT: If the input is true, then the output is false. If the input is false, then the output is true.", MessageType.Info);
            EditorGUILayout.HelpBox("Output based on a single input (Input1)", MessageType.Warning);
        }
        else if(logicGateController.warningType == "NAND")
        {
            EditorGUILayout.HelpBox("NAND (not-AND): The output is false if both inputs are true. Otherwise, the output is true.", MessageType.Info);
        }
        else if(logicGateController.warningType == "NOR")
        {
            EditorGUILayout.HelpBox("NOR (not-OR): output is true if both inputs are false. Otherwise, the output is false.", MessageType.Info);
        }
        else if(logicGateController.warningType == "XNOR")
        {
            EditorGUILayout.HelpBox("XNOR (exclusive-NOR): output is true if the inputs are the same, and false if the inputs are different", MessageType.Info);
        }

        // apply reference changes
        serializedObject.ApplyModifiedProperties();
    }

} // class end

#endif
