using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPhoton : Photon.MonoBehaviour
{
    //[SerializeField] private Text connectText;
  
    [SerializeField] private GameObject player, level,feikLevel;
    [SerializeField] private Transform spawnPoint;
     private ManagerColores managerColores;
    public GameObject Camerita;

   



    public GameObject endStateCanvas;

    private void Start()
    {
        Camerita.tag = "Untagged";
        managerColores = gameObject.GetComponent<ManagerColores>();
        endStateCanvas.gameObject.SetActive(false);
        PhotonNetwork.ConnectUsingSettings("1");
    
    }
    public virtual void OnJoinedLobby()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions(), null);
      
         
    }
    public void CreatePlayer()
    {

        Camerita.SetActive(false);
        feikLevel.SetActive(false);
        //spáwn the player
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation,0);
        //Deactivate the loby
        player.SetActive(true);

        Instantiate(level, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

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