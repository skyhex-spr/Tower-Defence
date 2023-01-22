using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObjects/Waves", order = 1)]
public class Waves : ScriptableObject
{
   public List<Wave> waves;
}

[System.Serializable]
public class Wave 
{
    public string waveName;
    public float StartTime;
    public List<Enemy> enemyList;
}

[System.Serializable]
public class Enemy
{
    public float HP;
    public float Speed;
    public int PlayerDamage;
    public int PlayerScore;
    public int Coin;
    public float SpawnTime;
    public float DelayTime;
    public int count;
    public EnemyType type;
    public GameObject Prefab;
}

public enum EnemyType
{
    Spearman,
    Swordman
}
