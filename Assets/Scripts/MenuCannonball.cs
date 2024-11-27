using UnityEngine;
public class MenuCannonball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MenuButton")
        {
            collision.gameObject.GetComponent<MenuButton>().Click();
        }
    }
}