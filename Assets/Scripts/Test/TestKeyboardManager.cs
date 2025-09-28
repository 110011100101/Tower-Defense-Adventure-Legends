using System.Collections;
using System.Collections.Generic;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestKeyboardManager : MonoBehaviour
{
    public Character[] characters;

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void TestRun()
    {
        foreach(Character character in characters)
        {
            character.SwitchRunState();
        }
    }

    public void TestShoot()
    {
        foreach(Character character in characters)
        {
            if(character is IRangedActions ranged)
            {
                ranged.SwitchShootState();
            }
        }
    }
}
