using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashLoader : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        this.asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!this.asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(this.asyncLoad.progress / 0.9f);
            this.percText.text = string.Format("{0:0.0}%", progress * 100f);
            this.barImg.fillAmount = progress;
            yield return new WaitForEndOfFrame();

        }
        this.asyncLoad = null;
        yield return new WaitForEndOfFrame();
        yield break;
    }

    public Text percText;

    public Image barImg;

    private AsyncOperation asyncLoad;
}
