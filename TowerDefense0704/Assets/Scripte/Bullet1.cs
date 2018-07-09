using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

    public float speed = 30f;
    private GameObject Target;
    public int Damage = 20;
    public GameObject BulletEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null)
        {
            transform.LookAt(Target.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //transform.localPosition  += transform.forward * Time.deltaTime* speed;
        }
        else {
            Destroy(this.gameObject);
        }
	}

    public void SetTarget(GameObject _Target) {
        Target = _Target;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Bullet1 OnTriggerEnter");
        if (other.tag == "Elements") {
            //1:销毁自己
            //2：爆炸特效
            //3：伤害传递
            Destroy(this.gameObject);//this指脚步，需删除子弹
            GameObject Effect =  Instantiate(BulletEffect, transform.position, Quaternion.identity);
            Destroy(Effect, 1);
            other.GetComponent<Element>().GetDamage(Damage);

        }
    }
}
