using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Настройки счета")]
    public int currentScore = 0;
    public Text scoreText;
    
    [Header("Настройки игры")]
    public string mainGameScene = "MainGame";
    public string menuScene = "MainMenu";
    
    void Awake()
    {
        // Создаем синглтон
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        UpdateScoreDisplay();
    }
    
    // Метод для добавления очков
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
    }
    
    // Обновление отображения счета
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{currentScore}";
        }
    }
    
    // Перезапуск игры
    public void RestartGame()
    {
        currentScore = 0;
        SceneManager.LoadScene(mainGameScene);
    }
    
    // Выход в меню
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
    
    // Выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}