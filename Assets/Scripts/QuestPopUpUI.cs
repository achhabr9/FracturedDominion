using UnityEngine;
using TMPro;
using System.Collections;

public class QuestPopupUI : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI popupText;
    public float popupDuration = 3f;

    public static QuestPopupUI Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowPopup(string message)
    {
        StopAllCoroutines();
        popupText.text = message;
        popupPanel.SetActive(true);
        StartCoroutine(HidePopup());
    }

    IEnumerator HidePopup()
    {
        yield return new WaitForSeconds(popupDuration);
        popupPanel.SetActive(false);
    }
}
