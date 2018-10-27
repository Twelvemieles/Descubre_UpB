
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mananger : MonoBehaviour {

    
    public int[] scenePaths;
    public float score = 0;
    public GameObject winState, textGame,target, cercaText;
    [SerializeField]
    private GameObject[] dianas;
    public Text finalScoreText, scoreText, cronoText;
    [SerializeField]
    private GameObject colisionparticle;

    [SerializeField]

    private float crono, cronof;
    public bool gameOver = false , muyCerca = false;
    public float distance;

    
    
	// Use this for initialization
	void Start () {
        dianas = GameObject.FindGameObjectsWithTag("Diana");
        cercaText.SetActive(false);
         score = 0;
        cronof = crono;
        scoreText.text = "Puntos:" + score;
        finalScoreText.text = "Puntos:" + score;
    }
	
	// Update is called once per frame
	void Update () {
      


        if (target.activeInHierarchy)
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
        }
        if (distance < 38)
        {
            muyCerca = true;
        }
        else
        {
            muyCerca = false;
        }

        if (muyCerca)
        {
            cercaText.SetActive(true);
        }
        else
        {
            cercaText.SetActive(false);
        }


        cronoText.text = "" + crono.ToString("0.0");

        for (int i = 0; i < dianas.Length; i++)
        {
            if(dianas[i] != null)
            {
                break;
            }
            else
            {
                if (i == dianas.Length - 1)
                {
                    gameOver = true;
                    PlayerPrefs.SetInt("pista", (PlayerPrefs.GetInt("pista") + 1));
                    print("se acabo");

                }
            }
        }
        if (crono <= 0 || gameOver)
        {
            EndLevel();

        }
        else
        {
            if (!muyCerca)
            {
                crono -= Time.deltaTime;
            }
            
        }
    }

    public void EndLevel()
    {
        gameOver = true;
        winState.SetActive(true);
        textGame.SetActive(false);
    }

    public void SumarPuntaje(int puntos, Transform pivot)
    {

        score += puntos;
        scoreText.text = "Puntos:" + score;
        finalScoreText.text = "Puntos:" + score;
        //Instantiate(colisionparticle, pivot.position, pivot.rotation);
    }
    public void Reiniciar()
    {
        //int i = Random.Range(0, scenePaths.Length);
        
        SceneManager.LoadScene(scenePaths[5]);
    }
    public void Lobby()
    {
        Master.tiro = false;
        SceneManager.LoadScene("Inicio");
    }
}
