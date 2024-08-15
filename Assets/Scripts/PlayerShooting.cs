using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 50f;
    public int bulletDamage = 20;
    public string targetTag = "Enemy";

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.Init(bulletDamage, targetTag);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
