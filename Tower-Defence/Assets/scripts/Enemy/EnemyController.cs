using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour , EnemyInterface
{
    private NavMeshAgent enemy;

    public static UnityEvent FinishedLine = new UnityEvent();
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(WaveManager.instance.Destination.position);

        if (!enemy.pathPending)
        {
            if (enemy.remainingDistance <= enemy.stoppingDistance)
            {
                if (!enemy.hasPath || enemy.velocity.sqrMagnitude < 0.5f)
                {
                    Debug.Log("One Enemy Arrived");
                    FinishedLine.Invoke();
                    Destroy(gameObject);
                }
            }
        }

    }

    public void SetHP(float HP)
    {
        this.HP = HP;
    }

    public void AddDamage(float Damage)
    {
        throw new System.NotImplementedException();
    }
}
