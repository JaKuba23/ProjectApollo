using System;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreCounter : MonoBehaviour
{
    public EndDialogueSystem endPanel;
    public int endScore;
    public static ScoreCounter Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText; 

    private int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UpdateScoreDisplay();
            
            if (score >= endScore)
            {
                EndGame(); 
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = $"{score} / {endScore}";
    }

    private void EndGame()
    {
        // Debug.Log("Koniec gry! Twój wynik to: " + score);
        // UnityEngine.SceneManagement.SceneManager.LoadScene(1); 
        endPanel.gameObject.SetActive(true);
        endPanel.Won = true;
        endPanel.Gadaj();
        this.gameObject.SetActive(false);
    }

    
}
