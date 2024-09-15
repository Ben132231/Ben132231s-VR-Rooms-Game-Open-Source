using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathScript : MonoBehaviour, ISaving
{
    float ResetTimer = 13;

    public GameObject ResetRoomsButton;
    public StatsManager statsManager;
    public AudioClip deathAudio;
    public LayerMask layerNothing;
    public LayerMask layerDefault;
    public float waitTime = 0.4f;

    bool TeleportingPlayer;
    bool Dead;

    public void TriggerDeath()
    {
        if (!GorillaLocomotion.Player.Instance.IsDead)
        {
            StuffManager.Instance.DeathScreenEffect.Play("Start_DeathScreenEffect");
            GorillaLocomotion.Player.Instance.IsDead = true;
            GorillaLocomotion.Player.Instance.GodMode = true;
            GorillaLocomotion.Player.Instance.DisableAllLightPowers();
            GorillaLocomotion.Player.Instance.ToggleLights(false);
            StuffManager.Instance.fastAudioManager.CreateFastAudio(deathAudio, Vector3.zero, 1f, 1f, 10000f, true);
            if (!StuffManager.Instance.IsCheating)
            {
                statsManager.AddToDeathCount();
                Save();
            }
        }
    }

    void Start()
    {
        ResetTimer = 13;
        ResetRoomsButton.SetActive(false);
        GorillaLocomotion.Player.Instance.IsDead = false;
    }

    void Update()
    {
        if(GorillaLocomotion.Player.Instance.IsDead)
        {
            ResetTimer -= Time.deltaTime;
        }
        if(ResetTimer < 0 && GorillaLocomotion.Player.Instance.IsDead && !Dead && SceneManager.GetActiveScene().name == "Rooms")
        {
            StuffManager.Instance.DeathScreenEffect.Play("Disable_DeathScreenEffect");
            GorillaLocomotion.Player.Instance.Health = GorillaLocomotion.Player.Instance.MaxHealth;
            GorillaLocomotion.Player.Instance.IsDead = false;
            ResetRoomsButton.SetActive(true);
            Dead = true;
            StartCoroutine(GodModeOff());
            StartCoroutine(teleport());
        }
        else if (ResetTimer < 0 && GorillaLocomotion.Player.Instance.IsDead && !Dead && SceneManager.GetActiveScene().name == "RoomsChaos")
        {
            SceneManager.LoadScene("Rooms");
        }
        if (TeleportingPlayer)
        {
            GorillaLocomotion.Player.Instance.transform.position = transform.position;
            GorillaLocomotion.Player.Instance.ToggleLights(true);
        }
    }

    IEnumerator teleport()
    {
        TeleportingPlayer = true;
        GorillaLocomotion.Player.Instance.locomotionEnabledLayers = layerNothing;
        yield return new WaitForSeconds(waitTime);
        GorillaLocomotion.Player.Instance.locomotionEnabledLayers = layerDefault;
        ResetTimer = 13;
        Dead = false;
        TeleportingPlayer = false;
    }

    IEnumerator GodModeOff()
    {
        yield return new WaitForSeconds(3);
        GorillaLocomotion.Player.Instance.GodMode = false;
    }

    public void Load()
    {
        
    }

    public void Save()
    {
        SavingManager.Save();
    }

    public void FinishSave()
    {
        
    }
}
