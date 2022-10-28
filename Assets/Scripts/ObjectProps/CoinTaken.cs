using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using UnityEngine;

public class CoinTaken : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinCounterService.Instance.AddCoin();
            Destroy(gameObject);
            CoinGeneratorService.Instance.Coins.Remove(gameObject);
        }
    }
}
