using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    internal void Refresh()
    {
        //for (int i = 0; i < this.upgrades.Length; i++)
        //{
        //    this.upgrades[i].SetProgress(PlayerDataPersistant.Instance.GetCarUpgradeValue(this.SelectedCar.carID, i), PlayerDataPersistant.Instance.GetMaxValue(this.SelectedCar.carID, i), PlayerDataPersistant.Instance.CarList[this.SelectedCar.carID].owned, this.upgradeIcon[i]);
        //}
        //if (PlayerDataPersistant.Instance.CarList[this.SelectedCar.carID].owned)
        //{
        //    for (int j = 0; j < this.colorItems.Length; j++)
        //    {
        //        this.colorItems[j].SetColorValue(this.carPreviews[this.SelectedCar.intID].carClrs[j], PlayerDataPersistant.Instance.GetCustomizationStatus(this.SelectedCar.carID, CustomiztionType.Color, j), PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currClr == j);
        //    }
        //    for (int k = 0; k < this.stickerItems.Length; k++)
        //    {
        //        this.stickerItems[k].SetItemImage(this.stickers[k], PlayerDataPersistant.Instance.GetCustomizationStatus(this.SelectedCar.carID, CustomiztionType.Sticker, k), PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currSticker == k);
        //    }
        //    for (int l = 0; l < this.rimItems.Length; l++)
        //    {
        //        this.rimItems[l].SetItemImage(this.rims[l], PlayerDataPersistant.Instance.GetCustomizationStatus(this.SelectedCar.carID, CustomiztionType.Rim, l), PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID).currRim == l);
        //    }
        //}
        //this.colorItems[0].Owned = true;
        //this.stickerItems[0].Owned = true;
        //this.rimItems[0].Owned = true;
        //this.ShowCustomizationUI(-1);
        //this.ResetValues();
        //for (int m = 0; m < this.carPreviews.Length; m++)
        //{
        //    this.carPreviews[m].SetActive(m == UIManager.GaragePage.CurrCarID);
        //}
    }

    public void BackFromPurchaseUI()
    {
        Singleton<UIManager>.Instance.ShowPage(UIScreens.FirstLand);
    }
    public CustomPanel[] customPanels;
    public GameObject previewParent;

    public GameObject purchaseUI;

    private UICarUpgradeItem[] upgrades;
    public GameObject backBtn;
    public Text custCostText;

    private int custPanel;
    public Sprite[] sp;
    public Sprite[] rims;
    public Sprite[] upgradeIcon;
    public Sprite[] stickers;
    public Sprite[] spCust;
}
