using TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers;
using TowerDefenseAdventureLegends.Assets.Scripts.Enum;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using UnityEngine;
using XLua;

public class Character : MonoBehaviour, ICharacterActions, ICharacterManger
{
    public string Name;
    public float BaseMaxHP;
    public float BaseMaxMP;
    public float BaseAttack;
    public float BaseDefense;
    public float BaseAttackSpeed;
    public float BaseAttackRange;
    public float BaseMoveSpeed;
    public float BaseRunningSpeed;

    public virtual CharacterType Type { get; set; } = CharacterType.Character;
    public float HP { get; set; }
    public float MP { get; set; }
    public float AttackValue { get; set; }
    public float DefenseValue { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }
    public float MoveSpeed { get; set; }
    public CharacterColorType color { get; set; }

    public void SwitchRunState()
    {
        bool isRun = GetComponent<Animator>().GetBool($"{nameof(isRun)}");

        if (isRun)
            MoveSpeed = BaseMoveSpeed;
        else
            MoveSpeed = BaseMoveSpeed * BaseRunningSpeed;

        GetComponent<Animator>().SetBool($"{nameof(isRun)}", !isRun);
    }

    public void SetAnimatorColor(CharacterColorType color)
    {
        this.color = color;

        GetComponent<Animator>().SetFloat("CharacterColor", (int)color);
    }

    void Start()
    {
        Initialized(Type);

        Debug.Log(Name);
    }

    void Update()
    {
        
    }

    protected void Initialized(CharacterType characterType)
    {

        LuaEnv luaEnv = new LuaManager().Initialized();
        luaEnv.DoString("require 'CharacterConfig'");
        LuaFunction getCharacterConfigFunction = luaEnv.Global.Get<LuaFunction>("GetCharacterConfig");

        LuaTable config = getCharacterConfigFunction.Call((int)characterType)[0] as LuaTable;

        if (config != null)
        {
            Name = config.Get<string>("Name");
            BaseMaxHP = config.Get<float>("BaseMaxHP");
            BaseMaxMP = config.Get<float>("BaseMaxMP");
            BaseAttack = config.Get<float>("BaseAttack");
            BaseDefense = config.Get<float>("BaseDefense");
            BaseAttackSpeed = config.Get<float>("BaseAttackSpeed");
            BaseAttackRange = config.Get<float>("BaseAttackRange");
            BaseMoveSpeed = config.Get<float>("BaseMoveSpeed");

            // 更新角色的属性
            HP = BaseMaxHP;
            MP = BaseMaxMP;
            AttackValue = BaseAttack;
            DefenseValue = BaseDefense;
            AttackSpeed = BaseAttackSpeed;
            AttackRange = BaseAttackRange;
            MoveSpeed = BaseMoveSpeed;
        }

        // 清理 Lua 环境
        luaEnv.Dispose();
    }
}
