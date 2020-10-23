using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> coins;
    private List<GameObject> obstacles;
    private Coroutine coin_coroutine;
    private Coroutine stop_coroutine;
    [SerializeField] private GameObject coin;
    Transform player;

    private void Awake()
    {
        coins = new List<GameObject>();
        obstacles = new List<GameObject>();
        player = GameObject.Find("Player").transform;
        Spawn(coin, 10, coins);
    }

    void Spawn(GameObject gameObject,int quantity,List<GameObject> list)
    {
        for(int i = 0; i < quantity; i++)
        {
            GameObject gmo = Instantiate(gameObject);
            gmo.SetActive(false);
            list.Add(gmo);
        }
    }

    private void OnEnable()
    {
        coin_coroutine = StartCoroutine(SpawnCoin(1.0f));
        stop_coroutine = StartCoroutine(Stop_Coin_Spawn(5f));
    }


    private IEnumerator SpawnCoin(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);

        while (true)
        {
            foreach (GameObject coin in coins)
            {
                if (coin.activeSelf == false)
                {
                    coin.SetActive(true);
                    coin.transform.position = GetRandom_Coin_SpawnPosition();
                    break;
                }
            }
            yield return wait;
        }
    }

    private Vector3 GetRandom_Coin_SpawnPosition()
    {
        int random_x = Random.Range(0, 2);

        int random_y = Random.Range(0, 2);

        if (random_x == 0)
        {
            if(random_y == 0)
            {
                return new Vector3(GameValues.Instance.Left_X_Boundary, 0.8f, player.position.z + 8f);
            }
            else
            {
                return new Vector3(GameValues.Instance.Left_X_Boundary, 4f, player.position.z + 8f);
            }
            
        }
        else
        {
            if(random_y == 0)
            {
                return new Vector3(GameValues.Instance.Right_X_Boundary, 0.8f, player.position.z + 5f);
            }

            else
            {
                return new Vector3(GameValues.Instance.Right_X_Boundary, 4f, player.position.z + 5f);
            }
        }
    }

    private IEnumerator Stop_Coin_Spawn(float time)
    {
        int random = Random.Range(0, coins.Count);
        WaitForSeconds wait = new WaitForSeconds(time);

        while (true)
        {

            if (coins[random].activeSelf == true)
            {
                coins[random].SetActive(false);
            }
           
            yield return wait;
        }     
    }

}
