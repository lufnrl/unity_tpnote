using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int CoinCount {get; private set;}
    public static int Score {get; private set;}
    public static bool IsGameWon {get; private set;}
    public static bool IsTimeUp {get; private set;}
    public static float TimeRemaining {get; private set;}

    [SerializeField] float timerLength = 300f;

    float _gameEndTime;
    void Start()
    {
        CoinCount = FindObjectsOfType<TomatoRipe>().Length; // Calculer le nombre de pièces dans la scène
        Debug.Log("Nombre de pièces : " + CoinCount); // Afficher le compte dans la console

        // Initialiser le score, l'état
        Score = 0;
        IsGameWon = false;
        IsTimeUp = false;
    
        // Calculer l'heure à laquelle la partie sera finie
        _gameEndTime = Time.time + timerLength;
    }

    void Update()
    {
        // Si le jeu est gagné ou perdu, ne rien mettre à jour
        if (IsGameWon || IsTimeUp)
        {
            return; // Sortir de la méthode Update()
        }

        // Calculer le temps restant
        TimeRemaining = _gameEndTime - Time.time;

        // Si le temps est écoulé, le jeu est perdu
        if (TimeRemaining <= 0f)
        {
            IsTimeUp = true;
            Debug.Log("Jeu perdu :(");
        }
    }

    public static void AddScore(bool isRipeTomato)
    {
        // If the game is lost, do nothing
        if (IsTimeUp)
        {
            return;
        }

        if (isRipeTomato)
        {
            Score++; // Increase score for ripe tomato
        }
        else
        {
            Score--; // Decrease score for unripe tomato
        }

        Debug.Log("Score : " + Score); // Display score in the console

        // If score equals the number of coins, the game is won
        if (Score == CoinCount)
        {
            IsGameWon = true;
            Debug.Log("Jeu gagné!");
        }
    }
}