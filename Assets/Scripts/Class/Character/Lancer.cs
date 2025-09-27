using TowerDefenseAdventureLegends.Assets.Scripts.Enum;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;

public class Lancer : Character, ILancerActions, ILancerManager
{
    public float Orientantion;
    public override CharacterType Type { get; set; } = CharacterType.Lancer;

    public void SwitchAttackState()
    {
        bool isAttack = GetComponent<Animator>().GetBool($"{nameof(isAttack)}");

        GetComponent<Animator>().SetBool($"{nameof(isAttack)}", !isAttack);
    }

    public void Defence()
    {
        bool isDefence = GetComponent<Animator>().GetBool($"{nameof(isDefence)}");

        GetComponent<Animator>().SetBool($"{nameof(isDefence)}", !isDefence);
    }

    public void SetOrientation()
    {

    }
}
