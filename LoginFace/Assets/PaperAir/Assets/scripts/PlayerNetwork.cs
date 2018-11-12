using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class PlayerNetwork : MonoBehaviour {

   //private Camera playerCamera;
    [SerializeField] private Behaviour[] playerControlScripts;
    [SerializeField] private GameObject canvas;


    private PhotonView photonView;
    private VuforiaBehaviour vuforiaB;
   
    private void Start()
    {
        //playerCamera = GetComponent<Camera>();
        photonView = GetComponent<PhotonView>();
        vuforiaB = GetComponent<VuforiaBehaviour>();
      

       Initialize();
    }
    private void Initialize()
    {
        if (!photonView.isMine)
        {

            // playerCamera.enabled = false;
            canvas.SetActive(false);
          
             foreach (Behaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }
        else
        {
           // GameObject cam = GameObject.FindGameObjectWithTag("BorrameCam");
            GameObject level = GameObject.FindGameObjectWithTag("BorrameLevel");
            //cam.SetActive(false);
            level.SetActive(false);
        }
    }
  
}
