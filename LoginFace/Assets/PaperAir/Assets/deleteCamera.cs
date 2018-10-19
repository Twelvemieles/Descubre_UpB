using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCamera : MonoBehaviour {
    public GameObject jugador;

    // Use this for initialization
    void Start () 
    {
      
    
    }
	
	// Update is called once per frame
	void Update () {
       var players = FindObjectOfType<ManangerAir>();
        if (players != null)
        {
            Destroy(gameObject);
        }

    }
}
