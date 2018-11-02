using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MIERDAAA : MonoBehaviour {
    public GameObject CamaraAR,CamaraNormal;
    public Transform Respawner;
    public int NumberScene;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     public void GoToTestRoom()
    {
        SceneManager.LoadScene(NumberScene);
    }
    public void InstanciateCamera()
    {
        Destroy(CamaraNormal);
        Instantiate(CamaraAR,Respawner.position,Respawner.rotation);
       
    }
}
