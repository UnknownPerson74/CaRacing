using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Load the gameplay scene
        SceneManager.LoadScene("Gameplay");
    }
}
