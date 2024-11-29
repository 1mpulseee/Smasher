using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BuyBuildButton : MonoBehaviour
{
    int id;
    DemoWorld world;
    [SerializeField] Outline outline;
    [SerializeField] BuildConfig CFG;
    [SerializeField] TMP_Text Price;
    [SerializeField] Image Icon;
    public void Setup(int id, DemoWorld world)
    {
        this.id = id;
        this.world = world;
        //Price.text = "Price:" + "\n" + CFG.Buildings[id].Price.ToString();
        //Icon.sprite = CFG.Buildings[id].Icon;
    }
    public void Select()
    {
        world.SelectBuild(id);
    }
    public void SetOutline(ButtonState state)
    {
        switch (state)
        {
            case ButtonState.Main:
                outline.effectColor = CFG.BaseButtonColor;
                break;
            case ButtonState.Selected:
                outline.effectColor = CFG.SelectedButtonColor;
                break;
            case ButtonState.Close:
                outline.effectColor = CFG.CloseButtonColor;
                break;
        }
    }
}