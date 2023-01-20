using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPointController : TowerBase
{

    public EasyTween Archer;
    public EasyTween Bomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        Archer.OpenCloseObjectAnimation();
        Bomb.OpenCloseObjectAnimation();
    }


}
