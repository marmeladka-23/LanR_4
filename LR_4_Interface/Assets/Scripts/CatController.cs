using UnityEngine;
using UnityEngine.SceneManagement;

public class CatControllerWithGameOver : MonoBehaviour
{
    [Header("Настройки кота")]
    public float moveSpeed = 5f;
    
    [Header("Настройки игры")]
    public string gameOverSceneName = "GameOver"; // Название сцены проигрыша
    public string obstacleTag = "Obstacle"; // Тег препятствий
    
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGameOver = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Если игра окончена, блокируем управление
        if (isGameOver) return;
        
        // Управление движением
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;
       
    }
    
    // Обработка столкновений с препятствиями
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag) && !isGameOver)
        {
            GameOver();
        }
    }
    
    // Обработка триггерных столкновений (если препятствия - триггеры)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(obstacleTag) && !isGameOver)
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        isGameOver = true;
        
        // Останавливаем движение
        rb.velocity = Vector2.zero;
        
        // Загружаем сцену проигрыша через 2 секунды (чтобы увидеть анимацию)
        Invoke("LoadGameOverScene", 2f);
        
        Debug.Log("Игра окончена! Кот врезался в препятствие.");
    }
    
    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}