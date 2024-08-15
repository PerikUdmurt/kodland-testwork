using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private float shootingRange = 15f;
    [SerializeField] private float stopDistance = 10f; 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 15f;
    [SerializeField] private float shootingInterval = 2f;
    private float shootingTimer;

    private void Update()
    {
        if (player == null) 
            return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        MoveToPlayer(distanceToPlayer);
        ShootToTarget(distanceToPlayer);
    }

    private void MoveToPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer > stopDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    private void ShootToTarget(float distanceToPlayer)
    {
        if (distanceToPlayer <= shootingRange)
        {
            if (shootingTimer <= 0f)
            {
                Shoot();
                shootingTimer = shootingInterval;
            }
            else
            {
                shootingTimer -= Time.deltaTime;
            }
        }
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.Init(20, "Player");
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
