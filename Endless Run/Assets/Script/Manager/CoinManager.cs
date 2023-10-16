using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 15;

    [SerializeField] GameObject coinPreFab;
    [SerializeField] Transform createPosition;

    void Start()
    {
        CreatCoin();
    }

    private void CreatCoin()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate(coinPreFab);

            coin.transform.SetParent(createPosition);

            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);
        }
    }

    
}
