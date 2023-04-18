using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI skorKiri;
    public TextMeshProUGUI skorKanan;

    public ScoreManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skorKiri.text = manager.leftScore.ToString();
        skorKanan.text = manager.rightScore.ToString();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }
}
