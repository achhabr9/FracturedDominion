using UnityEngine;

public class NPCDialogueChoice : MonoBehaviour
{
    public GameObject dialogueUI; // Assign your dialogue canvas here

    public void ChooseUnderstood()
    {
        FactionReputation.Instance.ChangeReputation("Nomad", 10);
        CloseDialogue();
    }

    public void ChooseBackOff()
    {
        CloseDialogue();
    }

    void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        Time.timeScale = 1f;

        // Hide and lock the cursor again
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
