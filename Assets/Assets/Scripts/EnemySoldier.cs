using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            DestroyBuilding();
        }
    }

    public virtual void DestroyBuilding()
    {
        if (this != null)
            Destroy(gameObject);
    }
}
