using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{

    public Canvas canvas;

    public GameObject CurrentTarget;
    protected float CurrentTargetDistance;

    public float radius;
    public float MaxDistance;
    public float Speed;
    public int Price;
    public LayerMask layerMask;

    protected Vector3 origin;
    protected Vector3 Direction;
    protected GameObject Bullet;

    public virtual void Start()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
            canvas.worldCamera = Camera.main;
        }

        origin = transform.position;
    }

    public virtual void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(origin, radius, layerMask);

        if (hitColliders.Length != 0)
        {
            ShootDesition(hitColliders);
        }
    }

    public virtual void ShootDesition(Collider[] hitColliders)
    {
    }

    public virtual void Shoot()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, radius);
    }

    public virtual void OnMouseDown()
    {
    }


}
