﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerTopos : MonoBehaviour {

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text finalScore;

    public bool noMasMonedas;

    private int scoreCoins;

    private float tiempo = 45;

    private AudioSource auds;

    [SerializeField]
    public GameObject win;
    public GameObject touch;

    private RaycastHit hit;
    private Ray ray;

    Vector3 worldPos;
    Vector2 wantedScreenSpawnPos;

    

    public static GameManagerTopos Instance { set; get; }

    // Use this for initialization
    void Start ()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        auds = GetComponent<AudioSource>();
        Time.timeScale = 1;
        Instance = this;
        score.text = scoreCoins.ToString("0");
        tiempoText.text = tiempo.ToString("0");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Enemy")
                {
                    if(noMasMonedas == false)
                    {
                        hit.collider.GetComponent<Topos>().tocado = true;
                    }
                }
                else
                {
                    touch.transform.position = hit.point + new Vector3(0, 0.01f, 0);
                    touch.SetActive(true);
                    touch.GetComponentInChildren<Animator>().Play("Bounce");

                }
            }
        }
    }

    private void FixedUpdate()
    {
        tiempo -= Time.fixedDeltaTime;
        tiempoText.text = tiempo.ToString("0");

        if(tiempo <= 0)
        {
            win.SetActive(true);
            Time.timeScale = 0;
            tiempo = 0;
            if(scoreCoins > 40)
            {
                finalScore.text = "Estrellas: 3";
            }
            if (scoreCoins > 20 && scoreCoins <= 40)
            {
                finalScore.text = "Estrellas: 2";
            }
            if (scoreCoins <= 20)
            {
                finalScore.text = "Estrellas: 1";
            }
            //actualizacion pista
            PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));

        }
    }
    public void GetCoin()
    {
        auds.Play();
        scoreCoins++;
        score.text = scoreCoins.ToString("0");
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("Topos");
    }

    public void Lobby()
    {
        Master.topos = false;
        SceneManager.LoadScene("Inicio");
    }
}
