using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;

public class Archer : Character, IArcherActions
{
    public void Defence()
    {
        GetComponent<Animator>().SetBool("isDefence", true);
    }

    public void Shoot()
    {
        GetComponent<Animator>().SetBool("isShoot", true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
