using UnityEngine;

public class Precious : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;
        currentHealth -= enemy.Damage;
        Debug.Log($"Health is now {currentHealth}");
    }
}
