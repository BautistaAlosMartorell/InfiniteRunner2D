using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Player player; // Asigna el Player aquí desde el Inspector
    public TextMeshProUGUI scoreText; // Texto para mostrar la puntuación en la UI
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreTextGameOver;// Texto para mostrar la puntuación máxima en la UI

    private float score;
    private float highScore;
    public GameObject aboutPanel;
    
    void Start()
    {
        // Inicializa la puntuación
        score = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Carga la puntuación máxima guardada
        UpdateUI();
    }

    void Update()
    {
        if (player.isAlive==true)
        {
            // Incrementa la puntuación basada en el tiempo de supervivencia
            score += Time.deltaTime;
            UpdateUI();
        }
        else
        {
            CheckHighScore();
        }
    }

    void UpdateUI()
    {
        // Actualiza el texto de la puntuación
        if (scoreText != null)
            scoreText.text = Mathf.FloorToInt(score).ToString();

        if (highScoreText != null)
            highScoreText.text = Mathf.FloorToInt(highScore).ToString();
        scoreTextGameOver.text = scoreText.text;
    }

    void CheckHighScore()
    {
        // Verifica si la puntuación actual es mayor que la puntuación máxima
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore); // Guarda la nueva puntuación máxima
        }
    }
   

    public void OpenPanel()
    {
        aboutPanel.SetActive(true);
    }
    public void QuitePanel()
    {
        aboutPanel.SetActive(false);
    }
}
