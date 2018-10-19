using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutos : MonoBehaviour {
    public GameObject[] images;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Active(int number)
    {
        images[number].SetActive(true);
    }

}
