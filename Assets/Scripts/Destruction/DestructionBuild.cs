using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DestructionBuild : DestructionCore
{
    bool IsDest;
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject Fragments;
    Quaternion Offset;
    protected override void Awake()
    {
        base.Awake();
        Offset = transform.rotation;
        Fragments.SetActive(false);
    }
    protected override void ChangeHealth(float dmg)
    {
        base.ChangeHealth(dmg);
    }
    protected override void Breakdown()
    {
        if (IsDest) { return; }
        IsDest = true;
        Fragments.transform.SetPositionAndRotation(transform.position, transform.rotation * Quaternion.Inverse(Offset));
        Fragments.SetActive(true);
        //GameObject NewEffect = Instantiate(Effect, transform.position, Quaternion.identity);
        //Destroy(NewEffect, 3f);
        Debug.LogWarning("DestructionBuild/Breakdown => turn on the effects when you add them");
        GameManager.instance.BuildingDestroyed();
        Destroy(gameObject);
    }
}