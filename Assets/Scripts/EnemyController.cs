using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector3 targetPosition;
    public int health = 20;


    void Start()
    {
        // Por ahora, ir hacia la base (posición en X = 0)
        targetPosition = new Vector3(0f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Base"))
        {
            BaseHealth baseHealth = collision.GetComponent<BaseHealth>();
            if (baseHealth != null)
            {
                baseHealth.TakeDamage(10); // Puedes ajustar el daño
            }

            Destroy(gameObject); // El enemigo desaparece tras golpear
        }
        
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(15); // Puedes ajustar el daño
            }

            Destroy(gameObject); // El enemigo muere tras atacar
        }

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            LootTable lootTable = GetComponent<LootTable>();
            if (lootTable != null)
            {
                lootTable.DropLoot(transform.position);
            }

            Destroy(gameObject);
        }
    }
    
}
