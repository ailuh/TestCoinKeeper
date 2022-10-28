using System;
using System.Collections;
using System.Drawing;
using System.Linq;

using UnityEngine;

public class HelpLinesService : Singleton<HelpLinesService>
{
    private LineRenderer _lineRenderer;
    public GameObject Player;
    Vector3[] pathPoints = new Vector3[6];
    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 6;
    }

    public void TurnOnLines()
    {
        StartCoroutine("HelpLinesWork");
    }
    public void TurnOffLines()
    {
        StopCoroutine("HelpLinesWork");
    }
    IEnumerator HelpLinesWork()
    {
        while (true)
        {
            if (CoinGeneratorService.Instance.Coins.Count > 0)
            {
                var coinsSorted = CoinGeneratorService.Instance.Coins.OrderBy(x => Vector3.Distance(x.transform.position, Player.transform.position));
                if (coinsSorted.Count() > 0)
                {
                    pathPoints[0] = Player.transform.position;
                    pathPoints[1] = coinsSorted.ElementAt(0).transform.position;
                    _lineRenderer.positionCount = 2;
                }
                if (coinsSorted.Count() > 1)
                {
                    pathPoints[2] = Player.transform.position;
                    pathPoints[3] = coinsSorted.ElementAt(1).transform.position;
                    _lineRenderer.positionCount = 4;
                }
                if (coinsSorted.Count() > 2)
                {
                    pathPoints[4] = Player.transform.position;
                    pathPoints[5] = coinsSorted.ElementAt(2).transform.position;
                    _lineRenderer.positionCount = 6;
                }
                _lineRenderer.SetPositions(pathPoints);
                yield return null;
            }
            else
            {
                break;
            }

        }
        yield break;
    }
}

