using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] ButtonType type;
    [SerializeField] GameObject full, blocks;
    [SerializeField] Rigidbody[] blocksRb;
    public void Click(Vector3 pos)
    {
        DestroyButton(pos);
        Invoke("qaz", 3f);
    }
    void DestroyButton(Vector3 pos)
    {
        full.SetActive(false);
        blocks.SetActive(true);
        for (int i = 0; i < blocksRb.Length; i++)
        {
            blocksRb[i].AddExplosionForce(150, pos, 50);
        }
    }
    void qaz()
    {
        switch (type)
        {
            case ButtonType.PlaySolo:
                SceneManager.LoadScene(1);
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