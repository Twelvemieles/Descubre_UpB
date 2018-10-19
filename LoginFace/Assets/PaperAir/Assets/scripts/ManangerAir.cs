using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManangerAir : MonoBehaviour {


    public GameObject wind;

    public bool windActive, myTurn;
    public GameObject myTurnGameObj;
    public ParticleSystem Extintor;
    public GameObject[]   colorTanks;
    private bool PVmine;
    public Animator anim;
   
   
  

    //1 = red , 2= green, 3 = blue, 4 = white
  
    public float time;
    
    private bool gameOver = false;
    private bool i = true;


    // Use this for initialization
    void Start()
    {
        PVmine = GetComponent<PhotonView>().isMine;

        wind.SetActive(false);
        myTurnGameObj.SetActive(true);



       int Playercolour = Random.Range(0, 4);
        colorTanks[Playercolour].SetActive(true);


    }
	// Update is called once per frame
	void Update() {


       
     
      wind.SetActive(windActive);
        if (windActive && myTurn)
        {
            Extintor.Play(true);
        }
        else
        {
            Extintor.Stop(true);
        }

        if (!gameOver)
        {
            time += Time.deltaTime;
          
        }

      
	}

    public void depressed()
    {
       
        windActive = false;



    }
    public void pressed()
    {
        if(myTurn)
        {
            windActive = true;

        }


    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
     
        if(stream.isWriting)
        {
            stream.SendNext(windActive);
            stream.SendNext(time);
            stream.SendNext(myTurn);
        }
        else
        {
            windActive = (bool)stream.ReceiveNext();
            time = (float)stream.ReceiveNext();
            myTurn = (bool)stream.ReceiveNext();

        }




    }

    [PunRPC]
    void Turnear(bool condition)
    {
        if (!myTurn && condition)
        {
            anim.SetTrigger("YourTurn");
        }
        myTurn = condition;
        if (PVmine)
        {
            myTurnGameObj.SetActive(!myTurn);
        }
       
       
    }



}

