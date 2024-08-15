using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;
    private string _target;

    public void Init(int damage, string targetTag)
    {
        _damage = damage;
        _target = targetTag;
    }

    public void OnTriggerEnter(Collider objectPoint)
    {
        if (objectPoint.CompareTag(_target))
        {
            objectPoint.GetComponent<Health>().TakeDamage(_damage);
            Destroy(this.gameObject);
        }
    }
}
