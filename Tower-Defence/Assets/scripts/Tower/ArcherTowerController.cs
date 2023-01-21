using System.Collections;
using System.Collections.Generic;
using UITween;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ArcherTowerController : TowerBase
{

    // Start is called before the first frame update
    public override void Start()
    {
       base.Start();
    }

    public override void ShootDesition(Collider[] hitColliders)
    {
        foreach (var hitCollider in hitColliders)
        {
            Debug.DrawLine(transform.position, hitCollider.transform.position, Color.white);
        }
        CurrentTarget = hitColliders[0].gameObject;
        Debug.DrawLine(transform.position, CurrentTarget.transform.position, Color.red);
        Shoot();
    }

    public override void Shoot()
    {
        if (CurrentTarget != null)
        {
            if (Bullet == null)
            { 
                Bullet = Instantiate(GameManager.Instance.ArrowPrefab, new Vector3(transform.position.x , transform.position.y + 5 , transform.position.z), transform.rotation, transform);
                Bullet.name = "Arrow";
                ArrowController Arrowcontroller = Bullet.GetComponent<ArrowController>();
                Arrowcontroller.speed = Speed;
                Arrowcontroller.target = CurrentTarget;
            }
        }
    }

}
