using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform attackPoint;
    public float attackRange = 1f;
    public int attackDamage = 15;
    public LayerMask enemyLayers;

    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    void Start()
    {
        enemyLayers = LayerMask.GetMask("Enemy"); // Esto forzará a usar esa capa
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento (izquierda/derecha)
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0);

        // Ataque
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Cambiable luego a botón táctil
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void Attack()
    {
        Debug.Log("¡Atacando!");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemigo golpeado: " + enemy.name);
            enemy.GetComponent<EnemyController>()?.TakeDamage(attackDamage);
        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

