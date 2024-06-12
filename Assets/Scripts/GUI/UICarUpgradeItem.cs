// dnSpy decompiler from Assembly-CSharp.dll class: UICarUpgradeItem
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UICarUpgradeItem : MonoBehaviour
{
	private void Awake()
	{
		this._id = base.transform.GetSiblingIndex();
        this.titleTxt.text = playerData[this._id];

    }

    public int CurrentProgress
	{
		get
		{
			return this._currProgress;
		}
		set
		{
			this._currProgress = value;
			this.costText.text = GetValueFormated(100 * this.CurrentProgress);
			this.addMore.SetActive(this._currProgress < this.max_progress);
			this.maxText.SetActive(this._currProgress >= this.max_progress);
		}
	}
    public static string GetValueFormated(float val)
    {
        return string.Format("{0:n0}", val);
    }
    public void SetProgress(int value, float max)
	{
		this.max_progress = max;
		this.CurrentProgress = value;
	}
    public void UpgradeIncrementValue()
    {
        if (this.CurrentProgress != max_progress)
        {
            if (MainMenu.Instance.Coins >= 100 * this.CurrentProgress)
            {
                this.CurrentProgress++;
                MainMenu.Instance.SetCarUpgradeValue(_id, this.CurrentProgress);
            }
            else
            {
                //Singleton<UIManager>.Instance.ShowPurchaseScreen();
            }
        }
    }

    public static string[] playerData = new string[]
{
        "Speed",
        "Brake",
        "Nitro",
};

    public Text titleTxt;

	public Text costText;

	public GameObject maxText;

	public GameObject addMore;

	private int _id;

	private int _currProgress;

	private float max_progress;

	private const int BASE_COST = 100;
}
