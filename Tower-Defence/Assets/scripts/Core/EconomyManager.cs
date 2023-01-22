using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{

    public int Coin;
    public TextMeshProUGUI CoinTXT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InititEconomy()
    {
        UpdateUI();
    }

    public void AddCoin(int coin)
    {
        Coin += coin;
        UpdateUI();

    }

    public void ReduceCoin(int coin)
    {
        Coin -= coin;
        if (Coin <= 0) Coin = 0;
        UpdateUI();

    }

    public void UpdateUI()
    {
        CoinTXT.text = Coin.ToString();
    }



}
