using TMPro;
using UnityEngine;

public class ReputationUI : MonoBehaviour
{
    public TextMeshProUGUI reputationText;

    void Update()
    {
        int syndicateRep = FactionReputation.Instance.GetReputation("Syndicate");
        int nomadRep = FactionReputation.Instance.GetReputation("Nomad");

        reputationText.text = $"Syndicate: {syndicateRep}\nNomad: {nomadRep}";
    }
}
