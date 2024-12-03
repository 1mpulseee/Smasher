using System.Runtime.InteropServices.WindowsRuntime;
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
    public virtual void ChangeHealth(float dmg)
    {
        if (!GameManager.Instance.GameStarted) return;
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
        float dmg = collision.impulse.magnitude;
        if (collision.transform.tag == "CannonBall")
        {
            dmg *= 5f;
        }
        ChangeHealth(dmg);
    }
    private void OnCollisionStay(Collision collision)
    {
        float dmg = collision.impulse.magnitude;
        if (collision.transform.tag == "CannonBall")
        {
            dmg *= 5f;
        }
        ChangeHealth(dmg);
    }
}