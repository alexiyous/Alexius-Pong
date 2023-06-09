using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject creator;
    public GameObject mainMenuCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Alex");
        mainMenuCanvas.SetActive(false);
        creator.SetActive(true);
    }

    public void CloseAuthor()
    {
        mainMenuCanvas.SetActive(true);
        creator.SetActive(false);
    }

}
