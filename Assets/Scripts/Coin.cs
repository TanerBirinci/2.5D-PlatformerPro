using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            _player.AddCoins();
            Destroy(this.gameObject);
        }
    }
}
