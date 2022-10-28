using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameOverService : Singleton<GameOverService>
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Button _restart;
    [SerializeField] Button _quit;
    [SerializeField] TextMeshProUGUI _recordText;
    [SerializeField] GameObject _player;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _restart.onClick.AddListener(RestartGame);
        _quit.onClick.AddListener(Quit);
    }

    public void GameOver(string wonOrNot)
    {
        HelpLinesService.Instance.TurnOffLines();
        var coinsCount = CoinCounterService.Instance.CoinCounter;
        _recordText.text = $"{wonOrNot}\nYour score : {coinsCount}";
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        CoinGeneratorService.Instance.StartGenerating();
        _gameOverPanel.SetActive(false);
        _player.transform.position = new Vector3(0, 1, 0);
    }

    void Quit()
    {
        Application.Quit();
    }
}
