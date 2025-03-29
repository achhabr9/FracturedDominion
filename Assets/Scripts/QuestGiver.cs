using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public QuestData quest;
    public GameObject questUI;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private bool playerNearby;
    private bool hasTalked = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !hasTalked)
        {
            hasTalked = true;
            StartCoroutine(ShowLoreThenComplete());
        }
    }

    System.Collections.IEnumerator ShowLoreThenComplete()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "The world was once united under one order... until the Syndicate fractured it. Be careful who you trust out here.";

        yield return new WaitForSeconds(5f); // Wait while player reads

        dialoguePanel.SetActive(false);
        QuestManager.Instance.CompleteQuest(quest);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            questUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            questUI.SetActive(false);
        }
    }
}
