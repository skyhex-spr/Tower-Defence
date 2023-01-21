using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : BulletController
{
    // Update is called once per frame
    public override void Update()
    {
        if (target == null) return;
        transform.LookAt(target.transform.position);
        dir = (target.transform.position - transform.position).normalized;
        rig.velocity = dir * speed;
    }
}
