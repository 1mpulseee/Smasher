using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DestructionBuild : DestructionCore
{
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject Fragments;
    Rigidbody rb;
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    protected override void ChangeHealth(float dmg)
    {
        base.ChangeHealth(dmg);
        if (Hp <= MapHP * .7f)
        {
            rb.isKinematic = false;
        }
    }
    protected override void Breakdown()
    {
        Fragments.SetActive(true);
        //GameObject NewEffect = Instantiate(Effect, transform.position, Quaternion.identity);
        //Destroy(NewEffect, 3f);
        Debug.LogWarning("DestructionBuild/Breakdown => turn on the effects when you add them");
        Destroy(gameObject);
    }
}