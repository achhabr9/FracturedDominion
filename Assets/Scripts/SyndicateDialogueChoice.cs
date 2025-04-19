using UnityEngine;

public class SyndicateDialogueChoice : MonoBehaviour
{
    public GameObject dialogueUI;

    public void ChooseTruth()
    {
        FactionReputation.Instance.ChangeReputation("Syndicate", 20);
        FactionReputation.Instance.ChangeReputation("Nomad", -10);
        CloseDialogue();
    }

    public void ChooseSilent()
    {
        CloseDialogue();
    }

    private void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        Time.timeScale = 1f;

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
