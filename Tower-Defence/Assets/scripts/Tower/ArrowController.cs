using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    Rigidbody rig;

    public float speed;
    public int damage;
    public GameObject target;

    Vector3 dir;
    // Start is called before the fiawrst frame update
    void Start()
    {
        rig= GetComponent<Rigidbody>();
        StartCoroutine(selfdestroy());
    }

    IEnumerator selfdestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.LookAt(target.transform.position);
        dir = (target.transform.position - transform.position).normalized;
        rig.velocity = dir * speed;
    }
}
