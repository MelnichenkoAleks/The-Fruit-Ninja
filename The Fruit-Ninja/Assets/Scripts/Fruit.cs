using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private AudioSource audioSource;
    public AudioClip fruitSound;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
  
    private ParticleSystem juiceEffect;// Система частиц для сока

    public int points = 1;

    private void Awake()
    {   
        audioSource = GameObject.FindGameObjectWithTag("Fruit").GetComponent<AudioSource>();
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        audioSource.PlayOneShot(fruitSound);
        FindObjectOfType<GameManager>().IncreaseScore(points);

        fruitCollider.enabled = false;
        whole.SetActive(false);

        sliced.SetActive(true);
        juiceEffect.Play();

        // Поворачиваем фрукт на основе угла разреза
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        // Добавляем силу к каждому кусочку на основе направления разреза
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

}
