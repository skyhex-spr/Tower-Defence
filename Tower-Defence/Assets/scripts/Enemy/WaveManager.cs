using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;

    private Wave currentwave;

    public Transform Destination;
    public int WaveHead = 0;
    private int OnlineEnemies = 0;

    public Transform EnemiesParent;

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
    // Update is called once per frame
    void Update()
    {
        
    }
}
