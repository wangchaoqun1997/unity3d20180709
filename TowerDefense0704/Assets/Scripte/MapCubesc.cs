using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCubesc : MonoBehaviour
{
    [SerializeField]
    public  Turret TurretObj;
    public bool HasTurret = false;
    public GameObject Effects;
    public bool TurretIsUpdate = false;
    private GameObject TurretObjTemp;
    public  void BuildTurret(Turret SelectTurret)
    {
        Debug.Log("BuildTurret.....");
        
        TurretObj = SelectTurret;
        Debug.Log(TurretObj.Obj);
        TurretObjTemp = Instantiate(TurretObj.Obj, transform.position, Quaternion.identity, TurretManger.AllTurrets.transform);
        GameObject obj = Instantiate(Effects, transform.position, Quaternion.identity);
        Destroy(obj,1);
        HasTurret = true;
    }

    public void UpdateTurret() {
        if (TurretIsUpdate == true) return;
        Debug.Log("UpdateTurret.....");
        Debug.Log(TurretObj.Obj);
        Instantiate(TurretObj.ObjUpgrade, transform.position, Quaternion.identity, TurretManger.AllTurrets.transform);
        Destroy(TurretObjTemp);
        TurretIsUpdate = true;
    }
    void OnMouseEnter() {
        if (HasTurret == false) {
            //GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void OnMouseExit() {
        //GetComponent<Renderer>().material.color = Color.white;
    }

}
