using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellChange : MonoBehaviour
{
    public List<GameObject> layouts = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {

        int randIndex = (int)Random.Range(0 ,layouts.Count);
        

        Instantiate(layouts[randIndex], transform.position, Quaternion.identity, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
