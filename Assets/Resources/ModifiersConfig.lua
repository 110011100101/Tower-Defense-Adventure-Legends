Modifiers =
{
    -- 前缀
    [-1] = {},
    [0] =
    {
        Name = "攻击力",
        Position = "Prefix",
        DataType = "Number",
        isGradable = true,
        GrowthRate = 40,
    },
    [1] =
    {
        Name = "法强",
        Position = "Prefix",
        DataType = "Number",
        isGradable = true,
        GrowthRate = 40,
    },
    [2] =
    {
        Name = "攻速",
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    [3] =
    {
        Name = "冷却缩减",
        Prefix = true,
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    [4] =
    {
        Name = "物理暴击率",
        Prefix = true,
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    [5] =
    {
        Name = "物理暴击伤害",
        Prefix = true,
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    [6] =
    {
        Name = "法术暴击率",
        Prefix = true,
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    [7] =
    {
        Name = "法术暴击伤害",
        Prefix = true,
        Position = "Prefix",
        DataType = "Percent",
        isGradable = false,
    },
    
    -- 后缀
    [8] =
    {
        Name = "生命值",
        Position = "Suffix",
        DataType = "Number",
        isGradable = true,
        GrowthRate = 40,
    },
    [9] =
    {
        Name = "防御力",
        Prefix = false,
        Position = "Suffix",
        DataType = "Number",
        isGradable = true,
        GrowthRate = 40,
    }
}

function GetModifiersConfig(index)
    return Modifiers[index]
end