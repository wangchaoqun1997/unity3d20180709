using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Element : MonoBehaviour {

    public Transform StartPosition;
    public GameObject prefab;
    public int MoveSpeed;
    public int BloodVolume = 100;
    public GameObject DieEffect;

    private Slider HpSlider;
    private int index = 0;
    private int TotalBloodVolume;
    // Use this for initialization
    void Start () {
        TotalBloodVolume = BloodVolume;
        HpSlider = GetComponentInChildren<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveElement();
    }

    void MoveElement() {
        if (index == GetTransformWayPonits.WayPoints.Length - 1)
        {
            ElementDie();
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, GetTransformWayPonits.WayPoints[index].position, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position,GetTransformWayPonits.WayPoints[index].position) < 0.1f) {
            index++;
        }
    }

    public void GetDamage(int Damage) {
        BloodVolume -= Damage;
        if (HpSlider != null)
        {
            HpSlider.value = (float)BloodVolume / TotalBloodVolume;
        }
        else
        {
            Debug.Log("------------------------------------");
        }
        if (BloodVolume <= 0) {
            ElementDie();
        }
    }

    public void ElementDie() {
        GameObject.Find("ElementsManger").GetComponent< ElementsManger >().Elements.Remove(this.gameObject);
        GameObject Effect = Instantiate(DieEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 1);
        Destroy(this.gameObject);
    }
}
