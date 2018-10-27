using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosTuto : MonoBehaviour
{
    public void Topos()
    {
        SceneManager.LoadScene("Topos");
    }
	
	public void Survive()
    {
        SceneManager.LoadScene("Survival");
    }

    public void Pong()
    {
        SceneManager.LoadScene("Hockey");
    }
    public void TiroAlBlanco()
    {
        SceneManager.LoadScene("Scene1"); ;
    }

    public void Viento()
    {
        SceneManager.LoadScene("escena1");

    }
}
