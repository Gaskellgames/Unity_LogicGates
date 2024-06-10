using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Code created by Gaskellgames: https://github.com/Gaskellgames
/// </summary>

namespace Gaskellgames.LogicSystem
{
    public class LogicGateController : MonoBehaviour
    {
        #region Variables

        public enum logicGates
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
        
        [SerializeField]
        private logicGates logicGate;
        
        [SerializeField]
        private LogicGate_Data info;
        
        [SerializeField]
        private UnityEvent OnEvent;
        
        [Space, SerializeField]
        private UnityEvent OffEvent;
        
        private logicGates logicGateCheck;
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

        public bool Input1
        {
            get => info.input1;
            set => info.input1 = value;
        }

        public bool Input2
        {
            get => info.input2;
            set => info.input2 = value;
        }

        public bool Output => info.output;

        public logicGates WarningType => logicGate;

        #endregion

    } // class end
}