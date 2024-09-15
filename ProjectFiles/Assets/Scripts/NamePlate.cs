using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class NamePlate : MonoBehaviour
{
    public List<string> BasicNames;
    public List<string> SpecialNames;
    public List<string> YoutubersNames;
    public TextMeshPro textObject;

    [Header("Unique Names")]
    public Color Ben132231Color;
    public Color HenryColor;

    void Awake()
    {
        var AllNames = BasicNames.Concat(SpecialNames).Concat(YoutubersNames).ToList();
        int ItemIndex = Random.Range(0, AllNames.Count);
        textObject.text = AllNames[ItemIndex];
        
        if (textObject.text.Contains("Ben132231"))
        {
            textObject.color = Ben132231Color;
        }
        if (textObject.text.Contains("Henry"))
        {
            textObject.color = HenryColor;
        }
    }
}
