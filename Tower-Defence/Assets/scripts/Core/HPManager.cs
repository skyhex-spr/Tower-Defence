using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class HPManager : MonoBehaviour
{

    public int HP;
    public TextMeshProUGUI HPTXT;

    public UnityEvent<bool> OnGameOver = new UnityEvent<bool>();
    public void InititHP()
    {
        UpdateUI();
    }

    public void Addhp(int hp)
    {
        HP += hp;
        UpdateUI();
    }

    public void Reducehp(int hp)
    {
        HP -= hp;
        if (HP <= 0) HP = 0;
        CheckHP();
        UpdateUI();
    }

    public void UpdateUI()
    {
        HPTXT.text = HP.ToString();
    }

    public void CheckHP()
    {
        if (HP == 0)
        {
            OnGameOver.Invoke(false);
        }
    }

}
