using UnityEngine;

public class QuestAutoGiver : MonoBehaviour
{
    public QuestData quest;

    void Start()
    {
        StartCoroutine(DelayedQuestGive());
    }

    System.Collections.IEnumerator DelayedQuestGive()
    {
        yield return new WaitForSeconds(0.2f); // small delay to ensure UI is initialized

        if (!quest.isCompleted)
        {
            QuestManager.Instance.AcceptQuest(quest);
        }
    }
}
