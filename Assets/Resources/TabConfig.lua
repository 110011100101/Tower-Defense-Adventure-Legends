Tab =
{
    [0] =
    {
        Name = "Equipment"
    },
    [1] =
    {
        Name = "Item"
    },
    [2] =
    {
        Name = "Skill"
    }
}

function GetTabCount()
    return #Tab + 1
end

function GetTabConfig(index)
    return Tab[index]
end