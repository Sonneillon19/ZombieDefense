using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Arma equipada")]
    public Weapon currentWeapon;           // Arma actual equipada (con su propio hitbox)
    public float attackDuration = 0.3f;    // Tiempo durante el cual el hitbox estará activo

    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Desactiva la hitbox del arma al iniciar
        if (currentWeapon != null)
        {
            currentWeapon.Deactivate();
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

        // Lanza la animación de ataque
        animator.SetTrigger("Attack");

        // Activa el hitbox del arma
        if (currentWeapon != null)
            currentWeapon.Activate();

        yield return new WaitForSeconds(attackDuration);

        // Desactiva la hitbox después de atacar
        if (currentWeapon != null)
            currentWeapon.Deactivate();

        isAttacking = false;
    }
}
