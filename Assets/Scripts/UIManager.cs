using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinText,livesText;

    private void Update()
    {
        
    }


    public void UpdateCoinDisplay(int coins)
    {
        coinText.text = "Coin: " + coins.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    
}
