using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaper : MonoBehaviour {
    public GameObject gameLogic;
   
    private ManagerPhoton manager;
  
    private TestPhoton actualizadorTiempo;





   
    public int colourBall;

	// Use this for initialization
	void Start () {
        manager = gameLogic.GetComponent<ManagerPhoton>();

        actualizadorTiempo = gameLogic.GetComponent<TestPhoton>();
        //StartCoroutine(ChangeColour());
    }
	
	// Update is called once per frame
	void Update () {
       


   

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Meta")
        {
            actualizadorTiempo.GameEnd();
            manager.EndState();
            PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
       


        }
    }
   

 
}

