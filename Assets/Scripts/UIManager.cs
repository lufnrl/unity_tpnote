using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;
    [SerializeField] TMP_Text textTime;
    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject gameOverScreen;

    void Start()
        {
        // Initialiser le texte de score
        textScore.text = "0 / 0";
    }

    void Update()
    {
        // Mettre à jour le texte de score
        textScore.text = GameManager.Score + " / " + GameManager.TomatoRipeCount;

        // Si le jeu est gagné, ne rien faire (bloquer le chronomètre)
        if (GameManager.IsGameWon)
        {
            return;
        }

        int _timeRemaining = (int)GameManager.TimeRemaining;

        // Afficher le temps restant en format MM:SS
        textTime.text = _timeRemaining / 60 + ":" + (_timeRemaining % 60).ToString("00");
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}