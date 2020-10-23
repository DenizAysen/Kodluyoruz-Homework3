using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CheckPointSystem
{
    public class CheckPointManager : MonoBehaviour
    {

        [SerializeField] private List<CheckPointController> checkPoints = new List<CheckPointController>();
     //   public GameObject[] Spawner;
        private int _lastPassedCheckPoint;
       
        private void Start()
        {
            for (int i = 0; i < checkPoints.Count; i++)
            {
                checkPoints[i].checkPointManager = this;
                if (i == 0) checkPoints[i].isMyTurn = true;
            }
        }

        public void SetLastPassedCheckPoint(int id)
        {
            _lastPassedCheckPoint = id;
            GameManager.Instance().ChangeCheckPoint(_lastPassedCheckPoint);

            if (checkPoints.Count - 1 > id)
            {
                checkPoints[id + 1].isMyTurn = true;
            }
            else
            {
                EndGame();
            }

        }

        private void EndGame()
        {
            Debug.Log("Level Completed");
          //  var adsManager = FindObjectOfType<Ads.AdsManager>();

        }
    }
}


