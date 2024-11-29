using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class DestructionFragment : DestructionCore
{
    [SerializeField] GameObject Effect;
    protected override void Breakdown()
    {
        //GameObject NewEffect = Instantiate(Effect, transform.position, Quaternion.identity);
        //Destroy(NewEffect, 3f);
        Debug.LogWarning("DestructionFragment/Breakdown => turn on the effects when you add them");
        Destroy(gameObject);
    }
}