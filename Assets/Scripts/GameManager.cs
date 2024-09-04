using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Player player; // Asigna el Player aqu� desde el Inspector
    public TextMeshProUGUI scoreText; // Texto para mostrar la puntuaci�n en la UI
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreTextGameOver;// Texto para mostrar la puntuaci�n m�xima en la UI

    private float score;
    private float highScore;
    public GameObject aboutPanel;
    
    void Start()
    {
        // Inicializa la puntuaci�n
        score = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Carga la puntuaci�n m�xima guardada
        UpdateUI();
    }

    void Update()
    {
        if (player.isAlive==true)
        {
            // Incrementa la puntuaci�n basada en el tiempo de supervivencia
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
        // Actualiza el texto de la puntuaci�n
        if (scoreText != null)
            scoreText.text = Mathf.FloorToInt(score).ToString();

        if (highScoreText != null)
            highScoreText.text = Mathf.FloorToInt(highScore).ToString();
        scoreTextGameOver.text = scoreText.text;
    }

    void CheckHighScore()
    {
        // Verifica si la puntuaci�n actual es mayor que la puntuaci�n m�xima
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore); // Guarda la nueva puntuaci�n m�xima
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
