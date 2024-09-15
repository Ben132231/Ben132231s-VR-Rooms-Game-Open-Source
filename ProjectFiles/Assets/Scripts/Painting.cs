using UnityEngine;
using TMPro;

public class Painting : MonoBehaviour
{
    public Material[] PaintingMaterials;

    public MeshRenderer PaintingImage;
    public TextMeshPro TitleText;

    string CorrectName;

    void Awake()
    {
        int RandomPainting = Random.Range(0, PaintingMaterials.Length);
        PaintingImage.material = PaintingMaterials[RandomPainting];
        CorrectName = PaintingImage.material.name.Replace(" (Instance)", "");
        TitleText.text = CorrectName;

    }
}
