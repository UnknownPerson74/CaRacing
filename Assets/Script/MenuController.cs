using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string selectedCar;
    public string selectedMap;

    public void ButtonClick()
    {
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
    }

    public void SelectCar(string carName)
    {
        selectedCar = carName;
        Debug.Log("SelectedCar:" + carName);
    }

    public void SelectMap(string mapName)
    {
        selectedMap = mapName;
        Debug.Log("SelectedMap:"+ mapName);
    }
}

