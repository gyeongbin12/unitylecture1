using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Percentage))]

public class CoinManager : MonoBehaviour
{
    private Percentage percentage;

    [SerializeField] bool flag;
    [SerializeField] int itemCount;
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 20;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] GameObject coinPreFab;
    [SerializeField] List<GameObject> coins;
    [SerializeField] Transform createPosition;

    void Start()
    {
        percentage = GetComponent<Percentage>();
        CreatCoin();
    }

    private void CreatCoin()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate(coinPreFab);

            coin.transform.SetParent(createPosition);

            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);

            coins.Add(coin);
        }
    }
    public void ActiveCoin()
    {
        foreach (var element in coins)
        {
            element.SetActive(true);
        }

        itemCount = percentage.Rand(50, out flag);

        if (flag == true)
        {
            coins[itemCount].SetActive(false);
        }
    }

    public void NewPosition()
    {
        ActiveCoin();

        createPosition.gameObject.SetActive(true);

        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);

        switch (roadLine)
        {
            case RoadLine.LEFT:
                createPosition.localPosition = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                createPosition.localPosition = Vector3.zero;
                break;
            case RoadLine.RIGHT:
                createPosition.localPosition = new Vector3(+positionX, 0, 0);
                break;
        }
    }
}
