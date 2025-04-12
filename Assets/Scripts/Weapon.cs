using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 20;
    public string enemyTag = "Enemy";
    public bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (other.CompareTag(enemyTag))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }
}
