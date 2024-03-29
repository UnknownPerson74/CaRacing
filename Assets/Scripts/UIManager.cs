using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager :  Singleton<UIManager>
{

    public static UIGaragePage GaragePage
    {
        get
        {
            return Singleton<UIManager>.Instance.garagePage;
        }
    }
    public UIGaragePage garagePage;
}
