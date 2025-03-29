using UnityEngine;

public class QuestResetter : MonoBehaviour
{
    public QuestData[] questsToReset;

    void Awake()
    {
        foreach (var quest in questsToReset)
        {
            quest.isCompleted = false;
        }
    }
}
