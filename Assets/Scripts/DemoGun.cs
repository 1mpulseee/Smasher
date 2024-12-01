using UnityEngine;
public class DemoGun : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] float Power;
    [SerializeField] Transform RifleStart;
    [SerializeField] Transform Cannon;
    [SerializeField] Transform Gyro;
    [SerializeField] ParticleSystem[] Effects;
    private void Awake()
    {
        Input.multiTouchEnabled = false;
        Gyro.parent = null;
    }

    void Update()
    {
        transform.rotation = Gyro.rotation;
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject NewCannonball = Instantiate(Ball, RifleStart.position, Quaternion.identity);
            NewCannonball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Power, ForceMode.Impulse);
            for (int i = 0; i < Effects.Length; i++)
            {
                Effects[i].Play();
            }
        }
    }
}
