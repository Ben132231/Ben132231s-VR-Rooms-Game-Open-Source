using UnityEngine.UI;
using UnityEngine;

public class ToggleFlying : MonoBehaviour
{
    public Image CheckMarkBox;
    public Sprite Checked;
    public Sprite Unchecked;

    bool toggle;

    public void FlyingToggle()
    {
        if (!toggle)
        {
            Player.Instance.CanFly = true;

            toggle = true;
            CheckMarkBox.sprite = Checked;
        }
        else
        {
            Player.Instance.CanFly = false;

            toggle = false;
            CheckMarkBox.sprite = Unchecked;
        }
    }
}
