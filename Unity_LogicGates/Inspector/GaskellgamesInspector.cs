using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gaskellgames
{
    #region Inspector Events

    [Serializable]
    public class InspectorEvent : UnityEvent { }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'ReadOnly' Attribute

    public class ReadOnlyAttribute : PropertyAttribute { }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'TagDropdown' Attribute

    // e.g: public string TagFilter = "";

    public class TagDropdownAttribute : PropertyAttribute
    {
        public bool UseDefaultTagFieldDrawer = false;
    }

    #endregion

} // class end
