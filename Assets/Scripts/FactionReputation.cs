using System;
using System.Collections.Generic;
using UnityEngine;

public class FactionReputation : MonoBehaviour
{
    public static FactionReputation Instance;

    private Dictionary<string, int> reputation = new Dictionary<string, int>();

    public event Action OnReputationChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ChangeReputation(string factionName, int amount)
    {
        if (!reputation.ContainsKey(factionName))
            reputation[factionName] = 0;

        reputation[factionName] += amount;

        OnReputationChanged?.Invoke(); // Notify listeners

        Debug.Log($"Reputation with {factionName} is now {reputation[factionName]}");
    }

    public int GetReputation(string factionName)
    {
        return reputation.ContainsKey(factionName) ? reputation[factionName] : 0;
    }
}
