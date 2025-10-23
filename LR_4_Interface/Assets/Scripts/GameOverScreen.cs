using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [Header("UI элементы")]
    public Text finalScoreText;
    public Button restartButton;
    public Button menuButton;
    
    void Start()
    {
        // Показываем финальный счет
        if (finalScoreText != null)
        {
            finalScoreText.text = $"Ваш счет: {GameManager.instance.currentScore}";
        }
        
        // Настраиваем кнопки
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(GoToMenu);
        }
    }
    
    void RestartGame()
    {
        GameManager.instance.RestartGame();
    }
    
    void GoToMenu()
    {
        GameManager.instance.GoToMenu();
    }
}