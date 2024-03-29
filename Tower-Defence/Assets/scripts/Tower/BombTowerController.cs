using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class BombTowerController : TowerBase
{

    public GameObject CanonHead;
    public Transform shootpoint;
    public float shootspeed = 1f;
    public int MinTargetDistance = 8;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ShootDesition(Collider[] hitColliders)
    {
        foreach (var hitCollider in hitColliders)
        {
            Debug.DrawLine(transform.position, hitCollider.transform.position, Color.white);
            if (math.abs(hitCollider.transform.position.x - transform.position.x) > MinTargetDistance)
            {
                CurrentTarget = hitCollider.gameObject;
                Debug.DrawLine(transform.position, CurrentTarget.transform.position, Color.red);
                break;
            }
        }
        Shoot();
    }

    public override void Shoot()
    {
        if (CurrentTarget != null)
        {
            {
                if (Bullet == null)
                {
                    Vector3 targetPos = CalculateVelocity(CurrentTarget.transform.position, CanonHead.transform.position, shootspeed);
                    CanonHead.transform.LookAt(targetPos);
                    Bullet = Instantiate(GameManager.Instance.BombPrefab, shootpoint.transform.position, Quaternion.identity);
                    Bullet.name = "Bomb";
                    Bullet.GetComponent<Rigidbody>().velocity = targetPos;
                    Bullet.GetComponent<BombController>().speed = Speed;

                }
            }
     
        }
    }

    Vector3 CalculateVelocity(Vector3 target , Vector3 origin ,float time) 
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }


}
