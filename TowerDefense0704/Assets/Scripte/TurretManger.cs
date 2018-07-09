using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretManger : MonoBehaviour {

    public Turret LaserTurret;
    public Turret MissileTurret;
    public Turret StandardTurret;
    private Turret SelectTurret;
    public RaycastHit MouseHit;
    private int AllMoney = 1000;
    public Text UserMoney;
    public Animator NoMoney;
    public static GameObject AllTurrets;
    public GameObject UpdateTurret;
    private GameObject UpdateCanvas;
    private GameObject RayHitCube;
    // Use this for initialization
    void Start () {
        UserMoney.text = "$" + AllMoney;
        AllTurrets = new GameObject("AllTurrets");
        SelectTurret = LaserTurret;
    }
	
	// Update is called once per frame
	void Update () {
            if (EventSystem.current.IsPointerOverGameObject() == false){

                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out MouseHit, 1000, LayerMask.GetMask("Map"));
                Collider HitCollider = MouseHit.collider;
                //Debug.Log(HitCollider.name);
                if (HitCollider != null && HitCollider.tag == "MapCube" && Input.GetMouseButtonDown(0))
                {
                    if (HitCollider.GetComponent<MapCubesc>().HasTurret == false && SelectTurret != null )
                    {
                        if (AllMoney - SelectTurret.Cost >= 0)
                        {
                            HitCollider.GetComponent<MapCubesc>().BuildTurret(SelectTurret);
                            HitCollider.GetComponent<MapCubesc>().HasTurret = true;
                            ChangeMoney(-SelectTurret.Cost);

                        }
                        else
                        {
                            NoMoney.SetTrigger("fliker");
                        }
                    }else if (HitCollider.GetComponent<MapCubesc>().HasTurret == true ){
                    //升级处理
                    RayHitCube = HitCollider.gameObject;
                        ShowUpdateCanvas(HitCollider.transform.position,true);
                    }

            }

        }
	}

    private void ShowUpdateCanvas(Vector3 pos, bool isOn) {
        if (UpdateCanvas == null)
        {
            UpdateCanvas = Instantiate(UpdateTurret, pos, Quaternion.identity);
        }
        else {
            UpdateCanvas.SetActive(false);
            UpdateCanvas.SetActive(true);
            UpdateCanvas.transform.position = pos;
        }
    }

    public void UpdateTurretFunction() {
        RayHitCube.GetComponent<MapCubesc>().UpdateTurret();
    }
    private void ChangeMoney(int Money) {
        AllMoney += Money;
        UserMoney.text = "$" + AllMoney;


    }


    public void SelectLaserTurret(bool isOn)
    {
        SelectTurret = LaserTurret;
        Debug.Log("SelectLaserTurret");
    }
    public void SelectMissileTurret(bool isOn)
    {
        SelectTurret = MissileTurret;
        Debug.Log("SelectMissileTurret");
    }
    public void SelectStandardTurret(bool isOn)
    {
        SelectTurret = StandardTurret;
        Debug.Log("SelectStandardTurret");
    }
}

[System.Serializable]
public class Turret {
    public GameObject Obj;
    public GameObject ObjUpgrade;
    public int Cost;
    public int CostUpgrade;
    public TurretType TypeName;
}

public enum TurretType {
    LaserTurret,
    MissileTurret,
    StandardTurret,
}