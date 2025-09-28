using TowerDefenseAdventureLegends.Assets.Scripts.Enum;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;

public class Archer : Character, IArcherActions
{
    public override CharacterType Type { get; set; } = CharacterType.Archer;

    public void SwitchShootState()
    {
        bool isShoot = GetComponent<Animator>().GetBool($"{nameof(isShoot)}");

        GetComponent<Animator>().SetBool($"{nameof(isShoot)}", !isShoot);
    }
}
