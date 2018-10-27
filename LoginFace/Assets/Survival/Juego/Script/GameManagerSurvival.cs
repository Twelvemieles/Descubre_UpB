using System.Collections;
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
    private Text Highscore;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text finalScore;
    [SerializeField]
    private Text tiempoFinal;
    [SerializeField]
    private Text tiempoFinal2;
    [SerializeField]
    private Text finalScore2;

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
        finalScore.text = "Puntaje final: " + scoreCoins.ToString("0");
        tiempoFinal.text = "Tiempo: " + tiempo.ToString("0");

        highscore = PlayerPrefs.GetInt("highscore");
        Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

        if (scoreCoins > highscore)
        {
            highscore = scoreCoins;
            Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

            PlayerPrefs.SetInt("highscore", highscore);
        }

    }

    public void Win()
    {
        tiempoFinal2.text = "Tiempo: " + tiempo.ToString("0");
        finalScore2.text = "Puntaje final: " + (45/ tiempo).ToString("");
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
