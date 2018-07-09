using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsManger : MonoBehaviour {


    public List<ElementTypeAndCount> ElementTypeAndCount;

    public  List<GameObject> Elements;
    // Use this for initialization
    void Start () {
        StartCoroutine(CreateElements());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator CreateElements() {
        while (true)
        foreach(ElementTypeAndCount e in ElementTypeAndCount)
        {
            for (int i = 0; i < e.ElementCounts; i++)
            {
                Elements.Add(Instantiate(e.ElementType.prefab, e.ElementType.StartPosition.position, new Quaternion(0, 0, 0, 0), this.transform));
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);

        }


    }
}
[System.Serializable]
public class ElementTypeAndCount {
    public Element ElementType;
    public int ElementCounts;

}



