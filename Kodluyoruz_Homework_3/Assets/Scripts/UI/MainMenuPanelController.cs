using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanelController : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _quitButton;
    void Start()
    {
        _startButton.onClick.AddListener(StartButtonFunction);
        _quitButton.onClick.AddListener(QuitButtonFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartButtonFunction()
    {
        SceneManager.LoadScene("Main");
    }
    private void QuitButtonFunction()
    {
        Application.Quit();
    }
}
