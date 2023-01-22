using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public Waves WavesData;

    [Header("Enemy Start/End Postio")]
    public List<Transform> StartPositions;
    public GameObject SoldiersParent;

    [Header("BaseTowerConfigs")]
    public GameObject ArcherTower;
    public GameObject BombTower;
    public GameObject TowerParent;
    public GameObject ArrowPrefab;
    public GameObject BombPrefab;


    [Header("Particles")]
    public GameObject DeathParticlePrefab;
    public GameObject BallParticlePrefab;

    [Space(5)]
    public EasyTween Elements;
    public Canvas UICanvas;
    public GameObject MSGPrefab;


    [Space(5)]
   [HideInInspector] public EconomyManager economymanager;
   [HideInInspector] public HPManager hpmanager;
   [HideInInspector] public ScoreManager scoremanager;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        IntialGameUI();

        economymanager = GetComponent<EconomyManager>();
        hpmanager = GetComponent<HPManager>();
        scoremanager = GetComponent<ScoreManager>();

        hpmanager.OnGameOver.AddListener(GameOver);

        economymanager.InititEconomy();
        hpmanager.InititHP();
        scoremanager.InititScore();
        WaveManager.instance.StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntialGameUI()
    {
        Elements.OpenCloseObjectAnimation();
    }


    public void ShowMessage(string message)
    {
        GameObject newmsg = Instantiate(MSGPrefab, UICanvas.transform);
        newmsg.GetComponent<MessageBox>().Message(message);
    }



    public void GameOver()
    {
        Debug.Log("GameOver");
        SoldiersParent.SetActive(false);
    }

}
