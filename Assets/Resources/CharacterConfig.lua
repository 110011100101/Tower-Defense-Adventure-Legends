local CharacterTemplate = {
    BaseMaxHP = 100,
    BaseMaxMP = 50,
    BaseAttack = 10,
    BaseDefense = 5,
    BaseAttackSpeed = 1.0,     -- 每秒攻击次数
    BaseAttackRange = 64,      -- 攻击范围(像素)
    BaseMoveSpeed = 64,         -- 移动速度(像素/秒)
    BaseRunningSpeed = 2;       -- 跑步速度乘数(像素/秒)
}

Character = {
    [0] = {
        Name = "Character",
    },

    [1] = {
        Name = "Archer",
        BaseMaxHP = 80,
        BaseMaxMP = 60,
        BaseAttack = 15,
        BaseDefense = 3,
        BaseAttackSpeed = 0.5,      -- 射手攻击较慢
        BaseAttackRange = 64 * 5,   -- 射手攻击范围较大
        BaseMoveSpeed = 64
    },
    
    [2] = {
        Name = "Lancer",
        BaseMaxHP = 120,
        BaseAttack = 12,
        BaseDefense = 8,
        BaseAttackRange = 64 * 1.5  -- 近战角色攻击范围较小
    },
    
    [3] = {
        Name = "Monk",
        BaseMaxHP = 110,
        BaseMaxMP = 80,
        BaseAttack = 8,
        BaseDefense = 6,
        BaseAttackSpeed = 0.8
    },
    
    [4] = {
        Name = "Warrior",
        BaseMaxHP = 150,
        BaseAttack = 18,
        BaseDefense = 10,
        BaseMoveSpeed = 96          -- 战士移动速度较快
    }
}

-- 设置 metatable 实现继承，只对未定义的字段进行继承
for characterType, character in pairs(Character) do
    -- 继承时只添加不存在的字段
    for key, value in pairs(CharacterTemplate) do
        if character[key] == nil then
            character[key] = value
        end
    end
end

-- 获取角色配置的函数
function GetCharacterConfig(characterType)
    return Character[characterType] -- 返回角色配置
end