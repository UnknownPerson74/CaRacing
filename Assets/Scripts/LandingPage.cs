using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPage : MonoBehaviour
{
    public void OnClickChooseGame(bool arenaM)
    {
        LandingPage.arenaMode = arenaM;
        Singleton<UIManager>.Instance.ShowPage(UIScreens.GarageScreen);
    }
    public static bool arenaMode;
}
