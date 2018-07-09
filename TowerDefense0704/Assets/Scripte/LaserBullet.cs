using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {

    [SerializeField]
    public LineRenderer AnLineRenderer;
    private GameObject Target;
    private Transform StartPosition;

    public float speed = 30f;
    public int Damage = 20;
    public GameObject BulletEffect;

    // Use this for initialization
    void Start () {
        AnLineRenderer.startWidth = 0.4f;
        AnLineRenderer.endWidth = 0.4f;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(StartPosition.position);
        AnLineRenderer.SetPosition(0, StartPosition.position);
        AnLineRenderer.SetPosition(1, Target.transform.position);
        //if (Target == null)
            Destroy(this.gameObject);
    }
    public void SetTarget(Transform _StartPosition,GameObject _Target)
    {
        StartPosition = _StartPosition;
        Target = _Target;
    }

}
