using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class ChaosEffectsManager : MonoBehaviour
{
    public List<ChaosEffect> ChaosEffects;
    public List<Transform> TextTransfroms;
    public float SecondsUntilNextEffect = 30f;
    public GameObject TextPrefab;
    public TextMeshProUGUI TimerUI;
    public bool StartedChaos;

    public List<ChaosEffect> activeEffects = new List<ChaosEffect>();
    private List<TextMeshPro> activeEffectsTexts = new List<TextMeshPro>();
    private TextMeshPro textMesh;
    private int lastEventIndex = -1;
    private GameObject textObject;
    
    float Timer;
    int maxActiveEffects = 5;

    void Start()
    {
        Timer = SecondsUntilNextEffect;
        maxActiveEffects = 5;
    }

    public void TriggerChaosFirstDoor()
    {
        StartedChaos = true;
    }

    void Update()
    {
        if (StartedChaos)
        {
            Timer -= Time.deltaTime;
            TimerUI.text = "Next Effect : " + Mathf.Round(Timer).ToString();
            
            if (activeEffectsTexts.Count == 1 && activeEffects.Count == 1)
            {
                activeEffectsTexts[0].text = activeEffects[0].EventName;
            }
            if (activeEffectsTexts.Count == 2 && activeEffects.Count == 2)
            {
                activeEffectsTexts[1].text = activeEffects[1].EventName;
            }
            if (activeEffectsTexts.Count == 3 && activeEffects.Count == 3)
            {
                activeEffectsTexts[2].text = activeEffects[2].EventName;
            }
            if (activeEffectsTexts.Count == 4 && activeEffects.Count == 4)
            {
                activeEffectsTexts[3].text = activeEffects[3].EventName;
            }
            if (activeEffectsTexts.Count == 5 && activeEffects.Count == 5)
            {
                activeEffectsTexts[4].text = activeEffects[4].EventName;
            }

            if (Timer < 0)
            {
                Timer = SecondsUntilNextEffect;
                TriggerNewEffect();
            }
        }
    }

    void TriggerNewEffect()
    {
        if (activeEffects.Count >= maxActiveEffects)
        {
            return;
        }

        int index = GetRandomEventIndex();
        ChaosEffect newEvent = ChaosEffects[index];

        for (int i = 0; i < activeEffects.Count; i++)
        {
            if (activeEffects[i].chaosEffectType == newEvent.chaosEffectType)
            {
                activeEffects[i].Deactivate();
                activeEffects.RemoveAt(i);
                break;
            }
        }

        if (activeEffectsTexts.Count == 0)
        {
            textObject = Instantiate(TextPrefab, TextTransfroms[0]);
        }
        else if (activeEffectsTexts.Count == 1)
        {
            textObject = Instantiate(TextPrefab, TextTransfroms[1]);
        }
        else if (activeEffectsTexts.Count == 2)
        {
            textObject = Instantiate(TextPrefab, TextTransfroms[2]);
        }
        else if (activeEffectsTexts.Count == 2)
        {
            textObject = Instantiate(TextPrefab, TextTransfroms[2]);
        }

        textMesh = textObject.GetComponent<TextMeshPro>();

        newEvent.Activate();
        activeEffects.Add(newEvent);
        activeEffectsTexts.Add(textMesh);
        activeEffects.Sort();
        activeEffectsTexts.Sort();

        StartCoroutine(RemoveEventAfterDuration(newEvent, textMesh));
    }

    IEnumerator RemoveEventAfterDuration(ChaosEffect chaosEffect, TextMeshPro text)
    {
        yield return new WaitForSeconds(chaosEffect.duration);
        activeEffects.Remove(chaosEffect);
        activeEffectsTexts.Remove(text);
        Destroy(text.gameObject);
        activeEffects.Sort();
        activeEffectsTexts.Sort();
    }

    int GetRandomEventIndex()
    {
        if (ChaosEffects.Count <= 1)
        {
            return Random.Range(0, ChaosEffects.Count); // Return the only available event if only one exists
        }

        int newIndex;
        do
        {
            newIndex = Random.Range(0, ChaosEffects.Count);
        }
        while (newIndex == lastEventIndex); // Ensure the new index is different from the last

        return newIndex;
    }
}
