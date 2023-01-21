using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    protected Rigidbody rig;

    public float speed;
    public int damage;
    public GameObject target;

    protected Vector3 dir;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rig = GetComponent<Rigidbody>();
        StartCoroutine(selfdestroy());
    }

    public virtual IEnumerator selfdestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
