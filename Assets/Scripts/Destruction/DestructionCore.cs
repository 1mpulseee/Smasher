using UnityEngine;
public class DestructionCore : MonoBehaviour
{
    [SerializeField] protected float MapHP;
    protected float Hp;
    [SerializeField] float MinDamage;
    protected virtual void Awake()
    {
        Hp = MapHP;
    }
    protected virtual void Breakdown() { }
    protected virtual void ChangeHealth(float dmg)
    {
        if (dmg > MinDamage)
        {
            Hp -= dmg;
        }
        if (Hp <= 0)
        {
            Breakdown();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ChangeHealth(collision.impulse.magnitude);
        
    }
    private void OnCollisionStay(Collision collision)
    {
        ChangeHealth(collision.impulse.magnitude);
    }
}