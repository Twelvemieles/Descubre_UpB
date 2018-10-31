using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerColores : MonoBehaviour {
    //1 = red , 2= green, 3 = blue, 4 = white
    public int managerColourCount = 0;
    public int managerColour = 1;

    public BallPaper paperBall;
    public float changeColourTime = 5f;
    public float elapsedTime = 0;
    public GameObject[] jugadores;
    public bool master ;
	// Use this for initialization
	void Start () 
    {
        if (master){
            changeColour();
        }

       

    }
	
	// Update is called once per frame
	void Update () {
    if(master)
        {
             elapsedTime += Time.deltaTime;
             
             if (elapsedTime >= changeColourTime)
             {

                 changeColour();

             }
         }



    }
    public void changeColour()
    {
        elapsedTime = 0;
       
        jugadores = GameObject.FindGameObjectsWithTag("MainCamera");
        managerColourCount = jugadores.Length;
        managerColour = Random.Range(0, managerColourCount);
        for (int i = 0; i <= managerColourCount - 1; i++)
        {
            if (jugadores[i] != null)
            {
                if (i == managerColour)
                {

                    var view = jugadores[i].GetComponent<PhotonView>();
                    view.RPC("Turnear", view.owner, true);
                }
                else
                {
                    var view = jugadores[i].GetComponent<PhotonView>();
                    view.RPC("Turnear", view.owner, false);
                }
            }
          
      
        }




    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        stream.Serialize(ref managerColour);
    
        stream.Serialize(ref managerColourCount);

   
    }

}
