using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExampleSceneLoader : MonoBehaviour
{
    [SerializeField]
    private Button QuitButton;

    private void Start()
    {
        QuitButton.onClick.AddListener(QuitGame);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
   
    private void QuitGame()
    {
        Application.Quit();
    }
}
