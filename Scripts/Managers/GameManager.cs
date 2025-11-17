using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameOver = false;

    public bool GameOver => gameOver;

    void Start() 
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
        RestartLevel();
    }

    public void IncreaseTime(float amount) 
    {
        timeLeft += amount;
    }

    void DecreaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        pauseManager.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }

    void RestartLevel() // Reloads scene if gameOver is true
    {
        if (!gameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
