using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public List<QuestData> activeQuests = new List<QuestData>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

public void AcceptQuest(QuestData quest)
{
    if (!activeQuests.Contains(quest))
    {
        activeQuests.Add(quest);
        Debug.Log($"Accepted quest: {quest.questName}");

        QuestPopupUI.Instance?.ShowPopup($"Quest Started: {quest.questName}");
    }
}

public void CompleteQuest(QuestData quest)
{
    if (activeQuests.Contains(quest) && !quest.isCompleted)
    {
        quest.Complete();
        QuestPopupUI.Instance?.ShowPopup($"Quest Completed: {quest.questName}");
    }
}

}
