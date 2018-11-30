using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPreguntas : MonoBehaviour {

    [SerializeField]
    private GameObject[] pregu = new GameObject[10];

    [SerializeField]
    private GameObject correcto;

    [SerializeField]
    private GameObject incorrecto;


    public void Start()
    {
        if (PlayerPrefs.HasKey("pregunta"))
        {
            int temp = PlayerPrefs.GetInt("pregunta");
            Preguntas(temp);
        }
        else
        {
            int temp = 0;
            PlayerPrefs.SetInt("pregunta", temp);
            Preguntas(temp);
        }
        
    }


    public void Preguntas(int x)
    {
        if(x > 9)
        {
            int temp = 0;
            PlayerPrefs.SetInt("pregunta", temp);
            pregu[temp].SetActive(true);
        }
        pregu[x].SetActive(true);
    }
    public void Correcto()
    {
        correcto.SetActive(true);
        int temp1 = PlayerPrefs.GetInt("pregunta");
        int temp2= PlayerPrefs.GetInt("pista");

        PlayerPrefs.SetInt("pista", ( temp2 + 1));
        PlayerPrefs.SetInt("pregunta", (temp1 + 1));
    }
    public void Incorrecto()
    {
        incorrecto.SetActive(true);
    }
    public void Return()
    {
        SceneManager.LoadScene("Inicio");
    }
}
