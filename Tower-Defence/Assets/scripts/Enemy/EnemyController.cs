using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour , EnemyInterface
{
    private NavMeshAgent enemy;

    public GameObject DeathParticle;


    public static UnityEvent FinishedLine = new UnityEvent();
    public static UnityEvent OnDead = new UnityEvent();

    public float HP;
    public Slider HealthBar;
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Arrow")
        {
            Destroy(other.gameObject);
            AddDamage(other.GetComponent<ArrowController>().damage);
        }
        else if (other.gameObject.name == "Bomb")
        {
            AddDamage(other.GetComponent<BombController>().damage);
        }
            
    }

    public void SetHP(float HP)
    {
        this.HP = HP;
        HealthBar.maxValue= HP;
        HealthBar.value = HP;
    }

    public void AddDamage(float Damage)
    {
        this.HP -= Damage;
        HealthBar.value = HP;

        if (HP <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        OnDead.Invoke();
        Instantiate(GameManager.Instance.DeathParticlePrefab.transform, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
