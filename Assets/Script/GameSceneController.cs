using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private MenuController menuController;

    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();

        // Instantiate selected car and map prefabs
        Instantiate(Resources.Load("Assets/Prefabs/Cars"+ menuController.selectedCar));
        Instantiate(Resources.Load( "Assets/Prefabs/Maps"+menuController.selectedMap));
    }
}
