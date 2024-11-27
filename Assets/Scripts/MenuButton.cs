using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] ButtonType type;
    public void Click()
    {
        DestroyButton();
        Invoke("qaz", 3f);
    }
    void DestroyButton()
    {
        
    }
    //IEnumerator test()
    //{
    //    StartCoroutine(test());

    //    print("1");
    //    yield return new WaitForSeconds(3);
    //    print("1");
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(3);
    //    print("1");
    //    }
    //}
    void qaz()
    {
        switch (type)
        {
            case ButtonType.PlaySolo:
                //do somthing
                break;
            case ButtonType.PlayOnline:

                break;
            case ButtonType.Editor:

                break;
        }
    }
}
[System.Serializable]
public enum ButtonType {PlaySolo, PlayOnline, Editor}