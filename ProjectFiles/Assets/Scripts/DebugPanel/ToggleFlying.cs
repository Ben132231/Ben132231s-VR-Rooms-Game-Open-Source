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
            GorillaLocomotion.Player.Instance.CanFly = true;

            toggle = true;
            CheckMarkBox.sprite = Checked;
        }
        else
        {
            GorillaLocomotion.Player.Instance.CanFly = false;

            toggle = false;
            CheckMarkBox.sprite = Unchecked;
        }
    }
}
