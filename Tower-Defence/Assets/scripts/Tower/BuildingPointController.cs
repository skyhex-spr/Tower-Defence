using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        GameObject Prefab = null;
        int price = 0;

        switch (tower)
        {
            case "archer":
                Prefab = GameManager.Instance.ArcherTower;
                price = Prefab.GetComponent<ArcherTowerController>().Price;
                break;
            case "bomb":
                Prefab = GameManager.Instance.BombTower;
                price = Prefab.GetComponent<BombTowerController>().Price;
                break;
            default:
                break;
        }

        if (price <= GameManager.Instance.economymanager.Coin)
        {
            GameObject Tower = Instantiate(Prefab, transform.position, transform.rotation, GameManager.Instance.TowerParent.transform);
            GameManager.Instance.economymanager.ReduceCoin(price);
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.ShowMessage("NOT ENOUGH MONEY");
        }

  
    }

    public void OnMouseDown()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        Archer.OpenCloseObjectAnimation();
        Bomb.OpenCloseObjectAnimation();
    }


}
