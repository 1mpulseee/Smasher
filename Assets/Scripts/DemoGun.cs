using UnityEngine;
using UnityEngine.EventSystems;
public class DemoGun : MonoBehaviour
{
    [SerializeField] Transform RifleStart;
    [SerializeField] Transform Cannon;
    [SerializeField] Transform Gyro;
    [SerializeField] ParticleSystem[] Effects;
    [SerializeField] GameObject[] CannonBalls;
    [SerializeField] float[] Powers;
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
            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (!EventSystem.current.IsPointerOverGameObject(id))
                {
                    GameObject NewCannonball = Instantiate(CannonBalls[GameManager.instance.selected], RifleStart.position, Quaternion.identity);
                    NewCannonball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Powers[GameManager.instance.selected], ForceMode.Impulse);
                    for (int i = 0; i < Effects.Length; i++)
                    {
                        Effects[i].Play();
                    }
                }
            }
        }
    }
}
