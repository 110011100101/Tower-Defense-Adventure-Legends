using TowerDefenseAdventureLegends.Assets.Scripts.Enum;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;

    // Update is called once per frame
public class Monk : Character, IMonkActions
{
    public override CharacterType Type { get; set; } = CharacterType.Monk;

    public void SwitchHealState()
    {
        bool isHeal = GetComponent<Animator>().GetBool($"{nameof(isHeal)}");

        GetComponent<Animator>().SetBool($"{nameof(isHeal)}", !isHeal);
    }

    public void SwitchShootState()
    {
        bool isShoot = GetComponent<Animator>().GetBool($"{nameof(isShoot)}");

        GetComponent<Animator>().SetBool($"{nameof(isShoot)}", !isShoot);
    }
}
