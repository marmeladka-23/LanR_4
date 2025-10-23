using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Настройки предмета")]
    public int scoreValue = 1; // Количество очков за предмет
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что коснулся кот (по тегу)
        if (collision.CompareTag("Player"))
        {
            // Сообщаем менеджеру игры о собранном предмете
            GameManager.instance.AddScore(scoreValue);
            
            // Уничтожаем объект
            Destroy(gameObject);
        }
    }
}