using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorService : Singleton<CoinGeneratorService>
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] Vector2 _fieldSize;
    [SerializeField] int _screenSquare;
    public List<GameObject> Coins = new List<GameObject>();
    int _coinsCount;
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        Time.timeScale = 0;
        _coinsCount = (int)((_fieldSize.x * _fieldSize.y) / _screenSquare);
        StartGenerating();
    }

    public void StartGenerating()
    {
        if (Coins.Count > 0)
        {
            foreach (var coin in Coins)
            {
                Destroy(coin);
            }
            Coins.Clear();
        }
        StartCoroutine("GenerateCoins");
    }

    IEnumerator GenerateCoins()
    {
        var coinsCrate = new GameObject();
        coinsCrate.name = "Coins";
        for (int i = 0; i < _coinsCount; i++)
        {
            Vector3 coinPosition = new Vector3(
                Random.Range(-_fieldSize.x / 2, _fieldSize.x / 2), 
                1f, 
                Random.Range(-_fieldSize.y / 2, _fieldSize.y / 2)
                );

            var coin = Instantiate(_coinPrefab, coinPosition, Quaternion.identity);
            coin.transform.SetParent(coinsCrate.transform);
            var animator = coin.GetComponent<Animator>();
            animator.Play("CoinAnimation", 0, Random.Range(0, 1f));
            Coins.Add(coin);
            yield return null;
        }
        CoinCounterService.Instance.CoinsFullCount = _coinsCount;
        TimerService.Instance.ResetAndStartTimer();
        CoinCounterService.Instance.ClearCounter();
        HelpLinesService.Instance.TurnOnLines();
        Time.timeScale = 1;
    }

}
