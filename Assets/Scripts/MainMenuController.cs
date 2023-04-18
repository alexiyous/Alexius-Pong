using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject creator;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Alex");
        creator.SetActive(true);
    }

}
