using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Arma")]
    public GameObject weaponHitbox;              // Referencia al objeto hijo con el BoxCollider
    public float attackDuration = 0.3f;          // Cuánto tiempo permanece activa la hitbox
    
    [Header("Animación")]
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (weaponHitbox != null)
        {
            weaponHitbox.SetActive(false); // Asegura que la hitbox esté inactiva al iniciar
        }
        else
        {
            Debug.LogWarning("No se asignó el WeaponHitbox en el PlayerCombat.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;

        // Activar animación
        animator.SetTrigger("Attack");

        // Activar el arma (hitbox)
        if (weaponHitbox != null)
            weaponHitbox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        // Desactivar la hitbox después del tiempo
        if (weaponHitbox != null)
            weaponHitbox.SetActive(false);

        isAttacking = false;
    }
}
