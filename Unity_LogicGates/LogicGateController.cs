using System.Collections.Generic;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

public class LogicGateController : MonoBehaviour
{
    #region Variables

    private enum logicGates
    {
        BUFFER,
        AND,
        OR,
        XOR,
        NOT,
        NAND,
        NOR,
        XNOR
    }

    [Header("Logic Gate")] [Space]

    [SerializeField] private logicGates logicGate;
    private logicGates logicGateCheck;
    [SerializeField] private GameObject screen;
    [SerializeField] private List<Material> materials;
    [HideInInspector] public string warningType;
    [Space][SerializeField] private InspectorEvent OnEvent;
    [Space][SerializeField] private InspectorEvent OffEvent;
    [Space] [ReadOnly, SerializeField] private LogicGate_Data info;
    private bool outputCheck;

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region Game Loop

    private void Start()
    {
        logicGateCheck = new logicGates();
        if(logicGate == logicGates.BUFFER)
        {
            logicGateCheck = logicGates.NOT;
        }
        else
        {
            logicGateCheck = logicGates.BUFFER;
        }
    }

    void Update()
    {
        HandleLogic();
        HandleEvents();
    }

    #endregion

    //----------------------------------------------------------------------------------------------------
    
#if UNITY_EDITOR

    #region Editor

    private void OnDrawGizmos()
    {
        warningType = logicGate.ToString();
    }

    #endregion

#endif

    //----------------------------------------------------------------------------------------------------

    #region Functions

    private void HandleEvents()
    {
        if(outputCheck != info.output)
        {
            if (info.output)
            {
                OnEvent.Invoke();
            }
            else
            {
                OffEvent.Invoke();
            }

            outputCheck = info.output;
        }
    }

    private void HandleLogic()
    {
        if (logicGate == logicGates.BUFFER)
        {
            // set material
            if(logicGateCheck != logicGate && screen != null && materials.Count > 0)
            {
                screen.GetComponent<Renderer>().material = materials[0];
                logicGateCheck = logicGate;

                Debug.Log("Material set to BUFFER");
            }

            // BUFFER: If the input is true, then the output is true. If the input is false, then the output is false.
            if (info.input1)
            {
                info.output = true;
            }
            else
            {
                info.output = false;
            }
        }
        else if (logicGate == logicGates.AND)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 1)
            {
                screen.GetComponent<Renderer>().material = materials[1];
                logicGateCheck = logicGate;
            }

            // AND: The output is true when both inputs are true. Otherwise, the output is false.
            if (info.input1 && info.input2)
            {
                info.output = true;
            }
            else
            {
                info.output = false;
            }
        }
        else if(logicGate == logicGates.OR)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 2)
            {
                screen.GetComponent<Renderer>().material = materials[2];
                logicGateCheck = logicGate;
            }

            // OR: The output is true if either or both of the inputs are true. If both inputs are false, then the output is false.
            if (info.input1 || info.input2)
            {
                info.output = true;
            }
            else
            {
                info.output = false;
            }
        }
        else if(logicGate == logicGates.XOR)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 3)
            {
                screen.GetComponent<Renderer>().material = materials[3];
                logicGateCheck = logicGate;
            }

            // XOR (exclusive-OR): The output is true if either, but not both, of the inputs are true. The output is false if both inputs are false or if both inputs are true.
            if ((info.input1 && !info.input2) || (!info.input1 && info.input2))
            {
                info.output = true;
            }
            else
            {
                info.output = false;
            }
        }
        else if(logicGate == logicGates.NOT)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 4)
            {
                screen.GetComponent<Renderer>().material = materials[4];
                logicGateCheck = logicGate;
            }

            // NOT: If the input is true, then the output is false. If the input is false, then the output is true. 
            if (info.input1)
            {
                info.output = false;
            }
            else
            {
                info.output = true;
            }
        }
        else if(logicGate == logicGates.NAND)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 5)
            {
                screen.GetComponent<Renderer>().material = materials[5];
                logicGateCheck = logicGate;
            }

            // NAND (not-AND): The output is false if both inputs are true. Otherwise, the output is true.
            if (info.input1 && info.input2)
            {
                info.output = false;
            }
            else
            {
                info.output = true;
            }
        }
        else if(logicGate == logicGates.NOR)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 6)
            {
                screen.GetComponent<Renderer>().material = materials[6];
                logicGateCheck = logicGate;
            }

            // NOR (not-OR): output is true if both inputs are false. Otherwise, the output is false.
            if (info.input1 || info.input2)
            {
                info.output = false;
            }
            else
            {
                info.output = true;
            }
        }
        else if(logicGate == logicGates.XNOR)
        {
            // set material
            if (logicGateCheck != logicGate && screen != null && materials.Count > 7)
            {
                screen.GetComponent<Renderer>().material = materials[7];
                logicGateCheck = logicGate;
            }

            // XNOR (exclusive-NOR): output is true if the inputs are the same, and false if the inputs are different
            if ((info.input1 && info.input2) || (!info.input1 && !info.input2))
            {
                info.output = true;
            }
            else
            {
                info.output = false;
            }
        }
    }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region Getter / Setter

    public bool GetInput1() { return info.input1; }

    public void SetInput1(bool value) { info.input1 = value; }

    public bool GetInput2() { return info.input2; }

    public void SetInput2(bool value) { info.input2 = value; }

    public bool GetOutput() { return info.output; }

    #endregion

} // class end
