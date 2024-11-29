using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGun : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] float Power;
    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject NewCannonball = Instantiate(Ball, transform.position, Quaternion.identity);
                NewCannonball.GetComponent<Rigidbody>().AddForce((hit.point - transform.position).normalized * Power, ForceMode.Impulse);
            }
        }
    }
}
