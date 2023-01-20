using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterface  
{
    public void SetHP(float HP);
    public void AddDamage(float Damage);

    public void Dead();

}
