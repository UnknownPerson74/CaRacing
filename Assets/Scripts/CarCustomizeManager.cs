using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCustomizeManager : MonoBehaviour
{
    public bool PurchaseBtn
    {
        set
        {
            this.purchaseUI.SetActive(value);
            this.backBtn.SetActive(!value);
        }
    }
    public void ShowCustomizationUI(int id)
    {
        if (id >= 0)
        {
            this.RemoveUnownedCustomizations();
        }
        this.custPanel = id - 1;
        for (int i = 0; i < this.customPanels.Length; i++)
        {
            this.customPanels[i].SetActive(id == i);
        }
        this.PurchaseBtn = false;
    }
    private void RemoveUnownedCustomizations()
    {
        //if (this.SelectedItem && !this.SelectedItem.Owned)
        //{
        //    switch (this.SelectedItem.customiztionType)
        //    {
        //        default:
        //            this.SelectedItem = this.colorItems[PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currClr];
        //            break;
        //        case CustomiztionType.Sticker:
        //            this.SelectedItem = this.stickerItems[PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currSticker];
        //            break;
        //        case CustomiztionType.Rim:
        //            this.SelectedItem = this.rimItems[PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currRim];
        //            break;
        //    }
        //    this.UpdateCustomization(this.SelectedItem.customiztionType, this.SelectedItem.id);
        //}
    }
    public void BackFromPurchaseUI()
    {
        Singleton<UIManager>.Instance.ShowPage(UIScreens.FirstLand);
    }
    public CustomPanel[] customPanels;

    public GameObject purchaseUI;

    private UICarUpgradeItem[] upgrades;
    public GameObject previewParent;
    public GameObject backBtn;
    private int custPanel;
    public Sprite[] sp;
    public Sprite[] rims;
    public Sprite[] upgradeIcon;
    public Sprite[] stickers;
    public Sprite[] spCust;
}
