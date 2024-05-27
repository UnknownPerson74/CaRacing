using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static MainMenu;
public class UIGaragePage : MonoBehaviour
{

    private int currentVehicleNumber = 0;
    public VehicleSetting[] vehicleSetting;

    private VehicleSetting currentVehicle;
    public void NextVehicle()
    {
        //if (menuGUI.wheelColor)
        //{ 
        //    menuGUI.wheelColor.gameObject.SetActive(false);
        //}

        currentVehicleNumber++;
        currentVehicleNumber = (int)Mathf.Repeat(currentVehicleNumber, vehicleSetting.Length);

        foreach (VehicleSetting VSetting in vehicleSetting)
        {

            if (VSetting == vehicleSetting[currentVehicleNumber])
            {
                VSetting.vehicle.SetActive(true);
                currentVehicle = VSetting;
            }
            else
            {
                VSetting.vehicle.SetActive(false);

            }
        }
    }


    public void PreviousVehicle()
    {

        currentVehicleNumber--;
        currentVehicleNumber = (int)Mathf.Repeat(currentVehicleNumber, vehicleSetting.Length);

        foreach (VehicleSetting VSetting in vehicleSetting)
        {
            if (VSetting == vehicleSetting[currentVehicleNumber])
            {
                VSetting.vehicle.SetActive(true);
                currentVehicle = VSetting;
            }
            else
            {
                VSetting.vehicle.SetActive(false);
            }
        }
    }
    public int CurrCarID
    {
        get
        {
            return this._carID;
        }
        set
        {
            this._carID = value;
            this.ChangeSelectedCar();
        }
    }
    public void ChangeSelectedCar()
    {
        this.carCustomize.Refresh();
        this.priceTxt.text = GameUtils.GetValueFormated(this.SelectedCar.cost);
        //PlayerCustomizeData playerData = PlayerDataPersistant.Instance.GetPlayerData(this.SelectedCar.carID);
        //this.carCustomize.SetActive(playerData.owned);
        //this.purchaseUI.SetActive(!playerData.owned);
    }
    public CarData SelectedCar
    {
        get
        {
            return Singleton<GamePlay>.Instance.playerCars[this.CurrCarID];
        }
    }
    public void SetActive(bool ui, bool state)
    {
        base.gameObject.SetActive(state);
        if (state)
        {
            this.carCustomize.previewParent.SetActive(true);
            this.UICanvas.SetActive(ui);
            base.StopAllCoroutines();
            if (!ui)
            {
                this.garageCam.enabled = ui;
            }
            base.StartCoroutine(this.ChangeTransform(this.garageCam.transform, ui, 0.5f));
        }
    }
    public IEnumerator ChangeTransform(Transform obj, bool enableCamOrbit, float delay = 0.5f)
    {
        Transform targetObj = (!enableCamOrbit) ? this.landTrans : this.garageTrans;
        float elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            this.et = elapsedTime / delay;
            obj.localPosition = Vector3.Lerp(obj.localPosition, targetObj.localPosition, Mathf.SmoothStep(0f, 1f, this.et));
            obj.localRotation = Quaternion.Slerp(obj.localRotation, targetObj.localRotation, Mathf.SmoothStep(0f, 1f, this.et));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.localPosition = targetObj.localPosition;
        obj.localRotation = targetObj.localRotation;
        this.garageCam.enabled = enableCamOrbit;
        yield break;
    }

    public CarCustomizeManager carCustomize;
    public CameraOrbit garageCam; 
    public GameObject UICanvas;
    public Transform landTrans;
    private float et;
    public Transform garageTrans;
    private int _carID;

    public Text priceTxt;
}