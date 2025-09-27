using TowerDefenseAdventureLegends.Assets.Scripts.Enum;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;

public class Warrior : Character, IWarriorActions
{
    public override CharacterType Type { get; set; } = CharacterType.Warrior;

    public void SwitchAttackState()
    {
        bool isAttack = GetComponent<Animator>().GetBool($"{nameof(isAttack)}");

        GetComponent<Animator>().SetBool($"{nameof(isAttack)}", !isAttack);
    }

    public void SwitchGuardState()
    {
        bool isGuard = GetComponent<Animator>().GetBool($"{nameof(isGuard)}");

        GetComponent<Animator>().SetBool($"{nameof(isGuard)}", !isGuard);
    }
}
