using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FacebookScrip : MonoBehaviour
{
    public Text FriendsText;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();

                else
                    Debug.LogError("Couldn´t initialize");


            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });


        }
        else
            FB.ActivateApp();
    }


    #region Login / Logout
    public void FaceBookLogin()
    {
        var permissions = new List<string>() { "email" };
        FB.LogInWithReadPermissions(permissions);
        SceneManager.LoadScene("Inicio");

    }
   public void FacebookLogout()
    {
        FB.LogOut();
    }
    
    
    #endregion

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://www.facebook.com"), "Check it out");


    }
    #region Inviting
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Ven y disfruta de este maravilloso Entorno", title: "Descubre UPB");


    }

  public void FacebookInvite()
    {

        FB.Mobile.AppInvite(new System.Uri("")); // Link De descarga del juego
    }
    
    #endregion
    public void GetFriendsPlayingThisGame()
    {

        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
          {

              var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
              var friendsList = (List<object>)dictionary["data"];
              FriendsText.text = string.Empty;
              foreach (var dict in friendsList)
                  FriendsText.text += ((Dictionary<string, object>)dict)["name"];
          });

    }
}
