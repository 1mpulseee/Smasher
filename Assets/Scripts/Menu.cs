using UnityEngine;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject cannonball;
    [SerializeField] Transform RifleStart;
    bool SoundIsActive = true;
    [SerializeField] GameObject SoundOn, SoundOff;
    public void SoundChange()
    {
        SoundIsActive = !SoundIsActive;
        if (SoundIsActive)
        {
            AudioListener.volume = 0.1f;
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0.0f;
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
    }
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