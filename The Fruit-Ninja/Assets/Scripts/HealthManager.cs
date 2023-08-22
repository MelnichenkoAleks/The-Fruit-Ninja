using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{   
    public static int health = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        health = 3;
    }

    
    void Update()
    {
        foreach (Image image in hearts)
        {
            image.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

    }
}
