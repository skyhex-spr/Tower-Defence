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
    public GameObject HealthBar;
    public Canvas playercanvas;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        playercanvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.SetDestination(WaveManager.instance.Destination.position);

        HealthBar.transform.rotation = Quaternion.LookRotation(HealthBar.transform.position - Camera.main.transform.position);

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
