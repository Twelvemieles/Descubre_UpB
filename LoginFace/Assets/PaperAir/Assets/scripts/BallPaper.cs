using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaper : MonoBehaviour {
   
	
	// Update is called once per frame
	void Update () {
       


   

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Meta")
        {
            GameObject Master = FindWithTag("Logic");
            actualizadorTiempo.GameEnd();
            manager.EndState();
            PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
       


        }
    }
   

 
}

