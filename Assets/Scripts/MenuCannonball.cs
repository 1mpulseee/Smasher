using UnityEngine;
public class MenuCannonball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MenuButton")
        {
            collision.gameObject.GetComponentInParent<MenuButton>().Click(gameObject.transform.position);
        }
    }
}