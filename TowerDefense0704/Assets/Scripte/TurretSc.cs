using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSc : MonoBehaviour {

    public List<GameObject> Elements;
    public GameObject BulletPrefab;
    public Transform BulletPosition;

    private GameObject Bullets;
    private float TimeCount = 0;
    private float speed = 0.4f;
    public Transform Head;
    void Start() {
        Bullets = new GameObject("Bullets");
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Elements")
            Elements.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Elements")
            Elements.Remove(other.gameObject);
    }

    void Update() {

        if (Elements.Count > 0)
        {//1 炮塔转向目标
            SetTarget(Elements[0]);
            TimeCount += Time.deltaTime;
            if (TimeCount >= speed)
            {
                TimeCount = 0;
                Attack();
            }
            //Debug.Log("Elements.count no 0");
        }
    }

    void Attack() {
         for (int i = 0; i < Elements.Count; i++){
            if (Elements[i] == null)
            {
                Elements.Remove(Elements[i]);
                Debug.Log("Elements x == null");
            }
        }
        if (Elements.Count != 0)
        {
            
            //2 发射子弹到目标
            GameObject Bullet = Instantiate(BulletPrefab, BulletPosition.position, Quaternion.identity, Bullets.transform);
            //Debug.Log(Bullet);
            if (Bullet.GetComponent<Bullet1>() != null)
            {
                Debug.Log("script Bullet1");
                Bullet.GetComponent<Bullet1>().SetTarget(Elements[0]);
            }
            else if (Bullet.GetComponent<LaserBullet>() != null)
            {
                Debug.Log("script LaserBullet");
                Bullet.GetComponent<LaserBullet>().SetTarget(BulletPosition, Elements[0]);
            }
            //Destroy(obj, 0.5f);
        }
    }

    private void SetTarget(GameObject Target) {
        if(Target != null)
            Head.LookAt(Target.transform);
    }

}
