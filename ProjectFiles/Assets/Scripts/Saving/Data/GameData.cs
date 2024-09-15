using UnityEngine;

[System.Serializable]
public class GameData
{
    // DebugMenu
    [field: SerializeField] public bool DebugPanel_Enabled { get; set; }

    // CheckPoints
    [field: SerializeField] public bool Reach_A50 { get; set; }
    [field: SerializeField] public bool Reach_A100 { get; set; }
    [field: SerializeField] public bool Reach_A150 { get; set; }
    [field: SerializeField] public bool Reach_A200 { get; set; }
    [field: SerializeField] public bool Reach_A300 { get; set; }

    // Stats
    [field: SerializeField] public int deathCount { get; set; }
    [field: SerializeField] public int doorsOpened { get; set; }
    [field: SerializeField] public int entitysEncounterd { get; set; }

    // Other Values
    [field: SerializeField] public bool HasBeatTutorial { get; set; }

    // Settings
    [field: SerializeField] public bool PlayerTurning { get; set; }
    [field: SerializeField] public bool NewRooms { get; set; } = true;

    // Save File And Save File Locks
    [field: SerializeField] public string Username { get; set; }
    [field: SerializeField] public string LockCode { get; set; }
    [field: SerializeField] public bool LockedLoadButton { get; set; }

    // Badges
    [field: SerializeField] public bool HasBeatASection { get; set; }
    [field: SerializeField] public bool StupidBadge { get; set; }
}
