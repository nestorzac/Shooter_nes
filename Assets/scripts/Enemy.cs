using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string enemyToLook = "Player";

    [SerializeField]
    private float speed = 1f;
    private Transform objective;

    private Health health;


    private void Start()
    {
        objective = GameObject.FindGameObjectWithTag(enemyToLook).transform;
        health = GetComponent<Health>();
    }

    private void Update()
    {
        FollowObjective();
    }

    private void FollowObjective()
    {
        Vector3 direction = (objective.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health.TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
            Destroy(collision.gameObject);
        }

         if (collision.gameObject.CompareTag("Cylinder"))
        {
            health.TakeDamage(collision.gameObject.GetComponent<Cylinder>().Damage);
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
