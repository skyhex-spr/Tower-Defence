using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public Waves WavesData;

    [Header("Enemy Start/End Postio")]
    public List<Transform> StartPositions;

    [Header("BaseTowerConfigs")]
    public GameObject ArcherTower;
    public GameObject BombTower;
    public GameObject TowerParent;
    public GameObject ArrowPrefab;
    public GameObject BombPrefab;


    [Header("Particles")]
    public GameObject DeathParticlePrefab;
    public GameObject BallParticlePrefab;



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        WaveManager.instance.StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
