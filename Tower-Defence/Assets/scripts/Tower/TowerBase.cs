using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{

    public Canvas canvas;

    private void Start()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
            canvas.worldCamera = Camera.main;
        }
    }

    public virtual void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }

    void FixedUpdate()
    {
        if (canvas != null)
            canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
    }
}
