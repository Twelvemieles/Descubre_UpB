using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiScores : MonoBehaviour {
    [SerializeField] private Text scorePlayerTxt;
    [SerializeField] private Text scoreAiTxt;
    private int scorePlayer;
    private int scoreAi;

    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Lose;

    public void SumarPlayer()
    {
        scorePlayer++;
        if(scorePlayer >= 7)
        {
            Win.SetActive(true);
        }
    }

    public void SumarAi()
    {
        scoreAi++;
        if (scoreAi >= 7)
        {
            Lose.SetActive(true);
        }
    }

    public void Start()
    {
        
    }

    void Update () {
        scorePlayerTxt.text = scorePlayer.ToString();
        scoreAiTxt.text = scoreAi.ToString();
	}

    public void reiniciar()
    {
        SceneManager.LoadScene("Hockey");
    }
}
