using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public static SaveManager Instance()
    {
        return _instance;
    }
    
    public void SetMaxScore(int maxscore)
    {
        if (PlayerPrefs.GetInt("score_key") < maxscore)
        {
            PlayerPrefs.SetInt("score_key", maxscore);
        }
    }

    public int GetMaxScore()
    {
        if(PlayerPrefs.GetInt("score_key") == null)
        {
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt("score_key");
        }
       
    }
}
