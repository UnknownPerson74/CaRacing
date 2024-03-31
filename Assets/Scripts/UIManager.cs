using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager :  Singleton<UIManager>
{
    public void Start()
    {
        this.ShowPage(UIScreens.FirstLand);
    }
    public void ShowPage(UIScreens NewPage)
    {
        switch (NewPage)
        {
            case UIScreens.FirstLand:
                //this.spinUIMan.SetActive(false);
                this.landingPage.SetActive(true);
                //this.morePanels.HideAllMorePanels();
                UIManager.GaragePage.SetActive(false, true);
                //this.inGamePage.SetActive(false);
                //this.popupsMan.gameObject.SetActive(false);
                break;
            case UIScreens.GarageScreen:
                this.landingPage.SetActive(false);
                //this.morePanels.HideAllMorePanels();
                UIManager.GaragePage.SetActive(true, true);
                //this.inGamePage.gameObject.SetActive(false);
                break;
            case UIScreens.Init_Booster:
                //this.morePanels.HideAllMorePanels();
                //this.inGamePage.gameObject.SetActive(false);
                //this.gameInitializer.gameObject.SetActive(true);
                break;
            case UIScreens.PlayModeScreen:
                //this.inGamePage.gameObject.SetActive(true);
                break;
            case UIScreens.SpinUI:
                //this.morePanels.HideAllMorePanels();
                //this.landingPage.SetActive(false);
                //this.inGamePage.gameObject.SetActive(false);
                //this.garagePage.SetActive(false, false);
                //this.spinUIMan.SetActive(true);
                break;
        }
    }    
    public static UIGaragePage GaragePage
    {
        get
        {
            return Singleton<UIManager>.Instance.garagePage;
        }
    }
    public UIGaragePage garagePage;
    public GameObject landingPage;
}
