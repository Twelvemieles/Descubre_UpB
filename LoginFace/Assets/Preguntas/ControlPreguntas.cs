using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPreguntas : MonoBehaviour {

    [SerializeField]
    private GameObject[] pregu = new GameObject[5];

    [SerializeField]
    private GameObject correcto;

    [SerializeField]
    private GameObject incorrecto;


    public void Start()
    {
        int temp = PlayerPrefs.GetInt("pregunta");
        Preguntas(temp);
    }


    public void Preguntas(int x)
    {
        pregu[x].SetActive(true);
    }
    public void Correcto()
    {
        correcto.SetActive(true);
        PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));
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
