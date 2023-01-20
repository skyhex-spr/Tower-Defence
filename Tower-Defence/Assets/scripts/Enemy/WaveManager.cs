using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;

    [Header("Configs")]
    public Transform Destination;
    public TextMeshProUGUI WaveText;
    public EasyTween WavePanelTween;
    public EasyTween WaveTextTween;

    [Header("WaveParticle")]
    public ParticleSystem FinishLine;

    [Space(5)]
    public Transform EnemiesParent;

    private Wave currentwave;

    [HideInInspector]
    public int WaveHead = 0;
    private int OnlineEnemies = 0;

  

    // Start is called before the first frame update
    void Start()
    {
        EnemyController.FinishedLine.AddListener(OnEnemyFinishLineOrDestroy);
    }

    private void Awake()
    {
        instance = this;
    }
    #region StartWave
    public void StartWave()
    {
        currentwave = GameManager.Instance.WavesData.waves[WaveHead];
        List<Enemy> enemyList = currentwave.enemyList;
        PushWaveText(WaveHead+1);
        StartCoroutine(GenerateEnemy(enemyList));
        WaveHead++;
    }

    public IEnumerator GenerateEnemy(List<Enemy> enemyList)
    {

        yield return new WaitForSeconds(currentwave.StartTime);

        int rnd = Random.Range(0, GameManager.Instance.StartPositions.Count);
        for (int i = 0; i < enemyList.Count; i++)
        {

            yield return new WaitForSeconds(enemyList[i].DelayTime);

            for (int j = 0; j < enemyList[i].count; j++)
            {         
                GameObject enemy = Instantiate(enemyList[i].Prefab
                    , GameManager.Instance.StartPositions[rnd].transform.position
                    , GameManager.Instance.StartPositions[rnd].transform.rotation);

                EnemyController controller = enemy.GetComponent<EnemyController>();
                controller.SetHP(enemyList[i].HP);
                enemy.GetComponent<NavMeshAgent>().speed = enemyList[i].Speed;

                enemy.transform.parent = EnemiesParent;

                OnlineEnemies++;

                yield return new WaitForSeconds(enemyList[i].SpawnTime);
            }

        }
    }
    #endregion

    #region FinishWave
    void OnEnemyFinishLineOrDestroy()
    {
        OnlineEnemies--;
        FinishLine.Play();
        CheckWaveState();
    }

    private void CheckWaveState()
    {
        if (OnlineEnemies == 0)
        {
            Debug.Log("WAVE FINISHED");

            if (WaveHead < GameManager.Instance.WavesData.waves.Count)
                StartWave();
            else
                Debug.Log("GAME FINISHED");

        }
    }
    #endregion

    #region WaveNotification
    public void PushWaveText(int Wave)
    {
        WaveText.text = "WAVE " + Wave.ToString();
        WavePanelTween.OpenCloseObjectAnimation();
        WaveTextTween.OpenCloseObjectAnimation();
        StartCoroutine(HideWaveNotification());
    }

    IEnumerator HideWaveNotification()
    {
        yield return new WaitForSeconds(2);
        WavePanelTween.OpenCloseObjectAnimation();
        WaveTextTween.OpenCloseObjectAnimation();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
