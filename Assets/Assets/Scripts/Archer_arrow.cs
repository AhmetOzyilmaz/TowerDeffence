using UnityEngine;

public class Archer_arrow : MonoBehaviour {

    EnemySoldier target;

    public float speed = 1.0f;
    public int damage = 1;

    float p = 0.0f;

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

        Arrow_Movement();
        Distance_Check();
    }

    void Arrow_Movement()
    {
        /*not running part
         * 
         * Vector3.MoveTowards(transform.position, target.transform.position, speed * (Time.fixedDeltaTime) / 2);

        float deltaX = speed * Time.deltaTime;
        float deltaP = deltaX / Vector3.Distance(target.transform.position, transform.position);

        p+= speed * Time.deltaTime / Vector3.Distance(transform.position, target.transform.position);

        if (p < 1)
        {
            Vector3 linedP = transform.position + Vector3.Normalize(target.transform.position - transform.position) * p;
            float  x = Mathf.Sin(p) / 5;
            Vector3 linedPnot = linedP;

            linedPnot.y += x;
            transform.position = linedPnot;
        }
        */

        /* old running version 
         * */

        FindTarget();

        float distance = (Vector3.Distance(transform.position, target.transform.position));
        Debug.Log("target ->" + (target.transform.position) + "Time Delta " + Time.deltaTime);


        float y = transform.position.y;
        Vector3 nextposition = Vector3.MoveTowards(transform.position, target.transform.position, speed * (Time.fixedDeltaTime) / 2);
        //Vector3 nextposition = transform.position + Mathf.Sin(speed * (Time.deltaTime / 2) / 5;

        float SinValue = Mathf.Sin(Time.deltaTime / 2);

        if (SinValue < 0)
        {
            SinValue *= -1;
        }
        nextposition.y = y + (SinValue * Time.deltaTime);
       // Debug.Log("SIN ->" + (SinValue) + "Time Delta " + Time.deltaTime);
        transform.position = nextposition;
        


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
   
    void ExplodeOnTarget()
    {
        if (!target)
            return;

        target.TakeDamage(damage);
        // Destroy(gameObject);
        gameObject.active = false;

    }

}
