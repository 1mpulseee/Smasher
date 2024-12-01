using UnityEngine;
public class DestructionBuild : DestructionCore
{
    bool IsDest;
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject Fragments;
    AudioSource DestSound;
    Quaternion Offset;
    protected override void Awake()
    {
        base.Awake();
        Offset = transform.rotation;
        DestSound = GetComponentInParent<AudioSource>();
        Fragments.SetActive(false);
    }
    public override void ChangeHealth(float dmg)
    {
        base.ChangeHealth(dmg);
    }
    protected override void Breakdown()
    {
        if (IsDest) { return; }
        DestSound.Play();
        IsDest = true;
        Fragments.transform.SetPositionAndRotation(transform.position, transform.rotation * Quaternion.Inverse(Offset));
        Fragments.SetActive(true);
        //GameObject NewEffect = Instantiate(Effect, transform.position, Quaternion.identity);
        //Destroy(NewEffect, 3f);
        //Debug.LogWarning("DestructionBuild/Breakdown => turn on the effects when you add them");
        GameManager.instance.BuildingDestroyed();
        Destroy(gameObject);
    }
}