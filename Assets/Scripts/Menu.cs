using UnityEngine;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject cannonball;
    [SerializeField] Transform RifleStart;
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.tag == "MenuButton")
                {
                    GameObject NewCannonball = Instantiate(cannonball, RifleStart.position, Quaternion.identity);
                    NewCannonball.GetComponent<Rigidbody>().AddForce((hit.point - RifleStart.position).normalized * 250f, ForceMode.Impulse);
                }
            }
        }
    }
}