using TMPro;

using UnityEngine;

public class CoinCounterService : Singleton<CoinCounterService>
{
    [SerializeField] TextMeshProUGUI _counterText;
    public int CoinCounter { get; set; }
    public int CoinsFullCount { get; set; }
    protected override void Awake()
    {
        base.Awake();
    }

    public void AddCoin()
    {
        CoinCounter++;
        CoinsFullCount--;
        _counterText.text = CoinCounter.ToString();
        if (CoinsFullCount <= 0)
        {
            GameOverService.Instance.GameOver("You Won!");
        }
    }

    public void ClearCounter()
    {
        CoinCounter = 0;
        _counterText.text = CoinCounter.ToString();
    }
}
