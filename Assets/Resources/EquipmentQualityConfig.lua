EquipmentQuality = {
	-- 品质
	[0] = {
		Name = "普通",
		Color = "#F7F7F7",
        PrefixSlot = 0;
        SuffixSlot = 0;
        GodfixSlot = 0;
	},
	[1] = {
		Name = "稀有",
		Color = "#4C6BFF",
        PrefixSlot = 1;
        SuffixSlot = 1;
        GodfixSlot = 0;
	},
	[2] = {
		Name = "史诗",
		Color = "#7A4D8C",
        PrefixSlot = 2;
        SuffixSlot = 2;
        GodfixSlot = 0;
	},
	[3] = {
		Name = "传说",
		Color = "#E07B3A",
        PrefixSlot = 3;
        SuffixSlot = 3;
        GodfixSlot = 0;
	},
	[4] = {
		Name = "神作",
		Color = "#D33C3C",
        PrefixSlot = 4;
        SuffixSlot = 4;
        GodfixSlot = 1;
	},
}

function GetEquipmentQualityConfig(index)
    return EquipmentQuality[index]
end