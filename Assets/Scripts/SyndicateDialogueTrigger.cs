using UnityEngine;

public class SyndicateDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI;
    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);
            Time.timeScale = 0f;

            // Unlock and show cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueUI.SetActive(false);
            Time.timeScale = 1f;

            // Lock and hide cursor again
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
