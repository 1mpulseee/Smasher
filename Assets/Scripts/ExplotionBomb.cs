using UnityEngine;
public class ExplotionBomb : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float dmg;
    [SerializeField] GameObject effect;
    bool IsDone;
    private void OnCollisionEnter(Collision collision)
    {
        if (IsDone)
        {
            return;
        }
        IsDone = true;
        Instantiate(effect, transform.position, Quaternion.identity);
        Collider[] colls = Physics.OverlapSphere(transform.position, range);
        for (int i = 0; i < colls.Length; i++)
        {
            DestructionBuild db = colls[i].GetComponent<DestructionBuild>();
            if (db != null)
            {
                db.ChangeHealth(dmg / Vector3.Distance(db.transform.position, transform.position));
            }
            else
            {
                DestructionFragment df = colls[i].GetComponent<DestructionFragment>();
                if (df != null)
                {
                    df.ChangeHealth(dmg / Vector3.Distance(df.transform.position, transform.position));
                }
            }
        }
    }
}