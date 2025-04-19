using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Ability")]
public class Ability : ScriptableObject
{
    public string abilityName;
    public string description;
    public Sprite icon;
    public string faction; // "Syndicate" or "Nomad"
    public int reputationRequired;
}
