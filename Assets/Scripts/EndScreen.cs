using UnityEngine;
using TMPro;
using System;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    
    void Start()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\nYou got a score of" +
                                scoreKeeper.CalculateScore() + "%";
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Editor'da oyunu durdurur
        #else
        Application.Quit(); // Gerçek oyunda uygulamayı kapatır
        #endif
    }

    
}