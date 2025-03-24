using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI; // Assign your dialogue canvas here
    private bool playerNearby;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);
            Time.timeScale = 0f;

            // Show and unlock cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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

            // Hide and lock cursor again
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

