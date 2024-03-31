using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIGaragePage : MonoBehaviour
{
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
}