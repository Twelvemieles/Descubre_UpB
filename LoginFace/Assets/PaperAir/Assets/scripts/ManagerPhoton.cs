using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPhoton : Photon.MonoBehaviour
{
    //[SerializeField] private Text connectText;

    [SerializeField] private GameObject player, level;
    [SerializeField] private Transform spawnPoint;
     private ManagerColores managerColores;
    public GameObject Camerita;

   



    public GameObject endStateCanvas;

    private void Start()
    {
        Camerita.tag = "BorrameCam";
       
        managerColores = gameObject.GetComponent<ManagerColores>();
        endStateCanvas.gameObject.SetActive(false);
       
    
    }
    public virtual void OnJoinedLobby()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions(), null);




    }
    public virtual void OnJoinedRoom()
    {
        //
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
       // Camerita.SetActive(false);
        //feikLevel.SetActive(false);
        Instantiate(level, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        //spáwn the player

        //Deactivate the loby
        player.SetActive(true);

      

    }
    public void CreatePlayer()
    {
        PhotonNetwork.ConnectUsingSettings("1");
     

    }

    public virtual void OnCreatedRoom()
    {
        managerColores.master = true;
        managerColores.changeColour();

    }


    private void Update()
    {
       // connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }
    public void EndState()
    {
        endStateCanvas.SetActive(true);

    
    }
    public void Reiniciate()
    {
        SceneManager.LoadScene(0);
    }
  

}