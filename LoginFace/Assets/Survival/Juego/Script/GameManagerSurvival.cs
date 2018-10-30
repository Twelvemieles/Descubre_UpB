﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerSurvival : MonoBehaviour {

    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text tiempoFinal;
    [SerializeField]
    private Text tiempoFinal2;
    [SerializeField]
    private Text estrellas;

    private int scoreCoins;
    private int highscore;
    private float tiempo = 0;
    private bool muerto;

    

    public static GameManagerSurvival Instance { set; get; }

    void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
        Time.timeScale = 1;
        Instance = this;
        score.text = scoreCoins.ToString("0");
    }

    private void FixedUpdate()
    {
        if(muerto == false)
        {
            tiempo += Time.fixedDeltaTime;
        }

        tiempoText.text = tiempo.ToString("0");

        if(scoreCoins >= 20)
        {
            Win();
        }
    }

    public void GetCoin()
    {
        scoreCoins++;
        score.text = scoreCoins.ToString("0");
    }

    public void Loser()
    {
        muerto = true;
        lose.SetActive(true);
        tiempoFinal.text = "Tiempo: " + tiempo.ToString("0");
    }

    public void Win()
    {
        tiempoFinal2.text = "Tiempo: " + tiempo.ToString("0");
        if(tiempo <= 50)
        {
            estrellas.text = "Estrellas: 3";
        }
        if (tiempo > 50 && tiempo <= 80)
        {
            estrellas.text = "Estrellas: 2";
        }
        if (tiempo > 80)
        {
            estrellas.text = "Estrellas: 1";
        }

        Time.timeScale = 0;
        win.SetActive(true);
        PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("Survival");
    }

    public void Lobby()
    {
        Master.survival = false;
        SceneManager.LoadScene("Inicio");
    }

}
