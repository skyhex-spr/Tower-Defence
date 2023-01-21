using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : BulletController
{

    public override IEnumerator selfdestroy()
    {
        yield return new WaitForSeconds(speed);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        Instantiate(GameManager.Instance.BallParticlePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);  
    }
}
