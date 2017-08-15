using UnityEngine;

public class Bullet : MonoBehaviour {
    EnemySoldier target;

    public float speed = 1.0f;
    public int damage = 1;

    private void Update()
    {
        if (target)
        {
            MoveTowardsTarget();
        }
        else
        {
            FindTarget();
        }
    }


    void Distance_Check()
    {
        Vector3 distCheckPos = transform.position;
        distCheckPos.y = target.transform.position.y;
        if (Vector3.Distance(distCheckPos, target.transform.position) < 0.01f)
        {
            ExplodeOnTarget();
        }
    }


    void FindTarget()
    {
        target = null;

        EnemySoldier[] enmySol = FindObjectsOfType<EnemySoldier>();
            
        float closestDist = Mathf.Infinity;
        EnemySoldier closest = null;
        foreach (EnemySoldier ES in enmySol)
        {
            float dist = Vector3.Distance(transform.position, ES.transform.position);
            if (dist < closestDist)
            {
                closest = ES;
                closestDist = dist;
            }
        }

        target = closest;
    }

    void MoveTowardsTarget()
    {
        if (!target)
            return;

        float y = transform.position.y;
        Vector3 nextposition = Vector3.MoveTowards(transform.position, target.transform.position, speed * (Time.deltaTime / 2));
        nextposition.y = y;
        transform.position = nextposition;
        Distance_Check();
    }

     void ExplodeOnTarget()
    {
        if (!target)
            return;

        target.TakeDamage(damage);
       // Destroy(gameObject);
        gameObject.active = false;

    }

}
