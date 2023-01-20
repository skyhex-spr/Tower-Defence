using System.Collections;
using System.Collections.Generic;
using UITween;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ArcherTowerController : TowerBase
{
    public GameObject CurrentTarget;
    private float CurrentTargetDistance;


    public float radius;
    public float MaxDistance;
    public float Speed;
    public LayerMask layerMask;


    private Vector3 origin;
    private Vector3 Direction;
    private GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    void FixedUpdate()
    { 
        Collider[] hitColliders = Physics.OverlapSphere(origin, radius, layerMask);

        if (hitColliders.Length != 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                Debug.DrawLine(transform.position, hitCollider.transform.position, Color.white);
            }
            CurrentTarget = hitColliders[0].gameObject;
            Debug.DrawLine(transform.position, CurrentTarget.transform.position, Color.red);
            Shoot();
        }
    }



    public void Shoot()
    {
        if (CurrentTarget != null)
        {
            if (Arrow == null)
            { 
                Arrow = Instantiate(GameManager.Instance.ArrowPrefab, new Vector3(transform.position.x , transform.position.y + 5 , transform.position.z), transform.rotation, transform);
                Arrow.name = "Arrow";
                ArrowController Arrowcontroller = Arrow.GetComponent<ArrowController>();
                Arrowcontroller.speed = Speed;
                Arrowcontroller.target = CurrentTarget;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, radius);
    }

}
