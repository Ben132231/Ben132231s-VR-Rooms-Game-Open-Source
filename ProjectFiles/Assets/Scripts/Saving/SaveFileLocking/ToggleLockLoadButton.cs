using UnityEngine.UI;
using UnityEngine;

public class ToggleLockLoadButton : MonoBehaviour
{
    public bool toggle;

    public Image CheckBoxImage;
    public Sprite Checked;
    public Sprite Unchecked;

    public void ToggleButton()
    {
        if (!toggle)
        {
            CheckBoxImage.sprite = Checked;
            toggle = true;
        }
        else
        {
            CheckBoxImage.sprite = Unchecked;
            toggle = false;
        }
    }
}
