using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Image gameOverImage;
    public GameObject gameOverPanel;

    public AudioSource AudioSource;
    public AudioClip gameOverSound;

    private Blade blade;
    private Spawner spawner;

    private int score;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        ClearScene();

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();
    }

    private void ClearScene()
    {        
        Fruit[] fruits = FindObjectsOfType<Fruit>();// Находим все объекты типа Fruit в сцене

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        // Плавное затемнение экрана до белого цвета
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            gameOverImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        AudioSource.PlayOneShot(gameOverSound);

        yield return new WaitForSecondsRealtime(0.5f);

        gameOverPanel.SetActive(true);

        /* NewGame();

         elapsed = 0f;

         /* while (elapsed < duration)
         {
             float t = Mathf.Clamp01(elapsed / duration);
             gameOverImage.color = Color.Lerp(Color.white, Color.clear, t);

             elapsed += Time.unscaledDeltaTime;

             yield return null; */
    }
}
