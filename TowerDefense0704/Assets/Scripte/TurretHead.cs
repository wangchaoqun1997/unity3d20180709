using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour {
    private GameObject Target;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.transform);
        transform.Translate(Vector3.forward);
    }
    public void SetTarget(GameObject _Target)
    {
        Target = _Target;
    }
}
