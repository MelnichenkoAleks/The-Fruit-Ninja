using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;            
            FindObjectOfType<GameManager>().Explode();// Находим объект GameManager и вызываем метод Explode() для обработки взрыва
        }
    }

}
