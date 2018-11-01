using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPhoton : MonoBehaviour {

    public Text timeText, Starstext;

    int Stars;
    public GameObject[] jugadores;
    public float tiempo = 0, timeToEnd;
    public bool gameOver = false;
   
    // Use this for initialization
  
    void Start () {
    

    }
    private void Update()
    {

        if (!gameOver)
        {
            timeText.text = "" + tiempo;
            jugadores = GameObject.FindGameObjectsWithTag("MainCamera");
            tiempo = ObtenerTiempo(jugadores);
           
        }
      
      

       

       

    }
    // Update is called once per frame
  
  /*  void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        stream.Serialize(ref tiempo);
    }*/
    static float ObtenerTiempo(GameObject[] jugadores )
    {
       
        float sum = 0, realPlayers = 0;
        if(jugadores.Length != 0)
        {
            for (int i = 0; i < jugadores.Length; i++)
            {

                if (jugadores[i] != null)
                {

                    float t2 = jugadores[i].GetComponent<ManangerAir>().time;

                    sum = t2 + sum;

                    realPlayers++;

                }
            }
            var total = sum / realPlayers;
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i] != null)
                {
                    jugadores[i].GetComponent<ManangerAir>().time = total;
                }
            }
            return total;
        }
        else{
            return 0;
        }
        

    }
    public void GameEnd()
    {
        if (tiempo > timeToEnd + ((timeToEnd * 1) / 4)) Stars = 0;
        if (tiempo < timeToEnd + ((timeToEnd * 1) / 4)) Stars = 1;
        if (tiempo < timeToEnd ) Stars = 2;
        if (tiempo < ((timeToEnd * 3)/4)) Stars = 3;

        Starstext.text = "Stars: " + Stars;
         gameOver = true;
    }

}
