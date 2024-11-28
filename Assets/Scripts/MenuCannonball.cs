using UnityEngine;
using UnityEngine.Rendering;
public class MenuCannonball : MonoBehaviour
{
    bool Use = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MenuButton" && !Use)
        {
            Use = true;
            collision.gameObject.GetComponentInParent<MenuButton>().Click(gameObject.transform.position);
        }
    }
}