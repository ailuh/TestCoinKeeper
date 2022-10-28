using System.Collections;

using TMPro;

using UnityEngine;

public class TimerService : Singleton<TimerService>
{
    [SerializeField] TextMeshProUGUI _timerText;
    float _duration = 60;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ResetAndStartTimer()
    {
        StopAllCoroutines();
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        var time = _duration;
        while (time >= 0)
        {
            time -= Time.deltaTime;
            var integer = (int)time;
            float minutes = Mathf.Floor(integer / 60);
            float seconds = Mathf.RoundToInt(integer % 60);
            _timerText.text = $"{minutes}:{seconds}";
            yield return null;
        }
        GameOverService.Instance.GameOver("You Lose!");
    }
}
