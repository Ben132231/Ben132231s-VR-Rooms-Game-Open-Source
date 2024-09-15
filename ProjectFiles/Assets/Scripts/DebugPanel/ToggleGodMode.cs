using UnityEngine.UI;
using UnityEngine;

public class ToggleGodMode : MonoBehaviour
{
    public Image CheckMarkBox;
    public Sprite Checked;
    public Sprite Unchecked;

    bool toggle;

    public void GodeModeToggle()
    {
        if (!toggle)
        {
            GorillaLocomotion.Player.Instance.GodMode = true;
            CheckMarkBox.sprite = Checked;

            toggle = true;
            
        }
        else
        {
            GorillaLocomotion.Player.Instance.GodMode = false;
            CheckMarkBox.sprite = Unchecked;

            toggle = false;
            
        }
    }
}
