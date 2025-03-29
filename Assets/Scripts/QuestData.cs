using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/New Quest")]
public class QuestData : ScriptableObject
{
    public string questName;
    [TextArea] public string description;
    public string factionReward;
    public int reputationReward;
    public bool isCompleted;

    public void Complete()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            if (!string.IsNullOrEmpty(factionReward))
            {
                FactionReputation.Instance.ChangeReputation(factionReward, reputationReward);
            }
            Debug.Log($"Quest Complete: {questName}");
        }
    }
}
