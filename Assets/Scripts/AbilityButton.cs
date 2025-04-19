using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityButton : MonoBehaviour
{
    public TextMeshProUGUI abilityNameText;
    public TextMeshProUGUI descriptionText;
    public Image icon;
    public Button button;

    private Ability ability;

    public void Setup(Ability newAbility)
    {
        ability = newAbility;
        abilityNameText.text = ability.abilityName;
        descriptionText.text = ability.description;
        icon.sprite = ability.icon;

        Refresh();
        button.onClick.AddListener(() => Debug.Log($"Activated: {ability.abilityName}"));
    }

    public void Refresh()
    {
        int currentRep = FactionReputation.Instance.GetReputation(ability.faction);
        bool isUnlocked = currentRep >= ability.reputationRequired;

        button.interactable = isUnlocked;

        abilityNameText.color = isUnlocked ? Color.white : Color.gray;
        descriptionText.color = isUnlocked ? Color.white : Color.gray;
        icon.color = isUnlocked ? Color.white : new Color(1f, 1f, 1f, 0.4f);
    }
}