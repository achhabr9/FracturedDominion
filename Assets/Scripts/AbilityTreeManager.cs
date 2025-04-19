using System.Collections.Generic;
using UnityEngine;

public class AbilityTreeManager : MonoBehaviour
{
    public Ability[] abilities;
    public GameObject abilityButtonPrefab;
    public Canvas canvas;
    public GameObject abilityContainer;

    private List<AbilityButton> abilityButtons = new List<AbilityButton>();
    private bool isOpen = false;
    private bool buttonsGenerated = false;

    void Start()
    {
        abilityContainer.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FactionReputation.Instance.OnReputationChanged += RefreshAllButtons;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isOpen = !isOpen;
            ToggleAbilityTree(isOpen);
        }
    }

    void ToggleAbilityTree(bool open)
    {
        abilityContainer.SetActive(open);
        Time.timeScale = open ? 0f : 1f;
        Cursor.lockState = open ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = open;

        if (open && !buttonsGenerated)
        {
            GenerateAbilityButtons();
            buttonsGenerated = true;
        }
    }

    void GenerateAbilityButtons()
    {
        float startY = 200f;
        float spacing = -80f;

        for (int i = 0; i < abilities.Length; i++)
        {
            GameObject buttonObj = Instantiate(abilityButtonPrefab, abilityContainer.transform);
            buttonObj.transform.localPosition = new Vector3(0f, startY + spacing * i, 0f);

            AbilityButton button = buttonObj.GetComponent<AbilityButton>();
            button.Setup(abilities[i]);
            abilityButtons.Add(button);
        }
    }

    void RefreshAllButtons()
    {
        foreach (var button in abilityButtons)
        {
            button.Refresh();
        }
    }
}

