using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScene : MonoBehaviour {

    public GameObject tiro, conejos, hockey, zombie, ventilador;
    



    // Use this for initialization
    void Start () {
        int scene = PlayerPrefs.GetInt("vuforiaS");
        if(scene == 1)
        {
            ventilador.SetActive(true);
            tiro.SetActive(false);
            conejos.SetActive(false);
            zombie.SetActive(false);
            hockey.SetActive(false);
        }
        if (scene == 2)
        {
            ventilador.SetActive(false);
            tiro.SetActive(true);
            conejos.SetActive(false);
            zombie.SetActive(false);
            hockey.SetActive(false);
        }
        if (scene == 3)
        {
            ventilador.SetActive(false);
            tiro.SetActive(false);
            conejos.SetActive(true);
            zombie.SetActive(false);
            hockey.SetActive(false);
        }
        if (scene == 4)
        {
            ventilador.SetActive(false);
            tiro.SetActive(false);
            conejos.SetActive(false);
            zombie.SetActive(true);
            hockey.SetActive(false);
        }
        if (scene == 5)
        {
            ventilador.SetActive(false);
            tiro.SetActive(false);
            conejos.SetActive(false);
            zombie.SetActive(false);
            hockey.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
