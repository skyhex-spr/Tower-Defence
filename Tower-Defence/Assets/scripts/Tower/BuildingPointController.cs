using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPointController : MonoBehaviour
{

    public EasyTween Archer;
    public EasyTween Bomb;

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
            canvas.worldCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (canvas != null)
            canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
    }

    public void SetNewTower(string tower)
    {

        GameObject Prefab = new GameObject();

        switch (tower)
        {
            case "archer":
            Prefab = GameManager.Instance.ArcherTower;
                break;
            case "bomb":
                Prefab = GameManager.Instance.BombTower;
                break;
            default:
                break;
        }

        GameObject Tower = Instantiate(Prefab,transform.position,transform.rotation,GameManager.Instance.TowerParent.transform);
        Destroy(gameObject);
  
    }

    public void OnMouseDown()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        Archer.OpenCloseObjectAnimation();
        Bomb.OpenCloseObjectAnimation();
    }


}
