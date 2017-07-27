using UnityEngine;

public class Cannon_ball : MonoBehaviour {


    EnemySoldier target;
    public float speed = 1.0f;
    public int damage = 1;
    Rigidbody2D projectile;
    private void Start()
    {

    }
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

        Ball_Movement();
        Distance_Check();
    }

    void Ball_Movement()
    {
  
        var distance = Vector3.Distance(target.transform.position, transform.position);
        var piece = distance / 30;
        var height = Mathf.Tan(60) * piece;
        Vector3 moveDir = (target.transform.position - transform.position).normalized;

        moveDir.y+=Mathf.Sin(75 * (Mathf.PI / 180))/2;
        transform.position += moveDir * speed * Time.deltaTime;

    }

    void Distance_Check()
    {
        Vector3 distCheckPos = transform.position;
        distCheckPos.y = target.transform.position.y;
        if (Vector3.Distance(distCheckPos, target.transform.position) < 0.0001f)
        {
            ExplodeOnTarget();
        }
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
