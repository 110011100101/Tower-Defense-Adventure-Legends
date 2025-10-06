using TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers;
using UnityEngine;
using XLua;

public class EquipmentInformationPanelManager : MonoBehaviour
{
    public GameObject Icon;
    public GameObject BackGroundImage;
    public GameObject Name;
    public GameObject Quality;
    public GameObject[] OriginalModifiers;
    public GameObject[] PrefixSlots;
    public GameObject[] SuffixSlots;
    public GameObject GodfixSlot;

    void Start()
    {
        HidePanel();
    }

    void Update()
    {
        
    }

    public void ShowPanel()
    {
        transform.parent.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void SetPanelData(Equipment equipment, LuaManager luaManager)
    {
        if (equipment == null) { return; }

        if (transform.parent.gameObject.activeSelf == false) { return; }
        luaManager.LoadConfigScript("ModifiersConfig");
        luaManager.LoadConfigScript("EquipmentQualityConfig");

        LuaFunction GetEquipmentQualityConfig = luaManager.GetFunction("GetEquipmentQualityConfig");
        LuaFunction GetModifiersConfig = luaManager.GetFunction("GetModifiersConfig");
        LuaTable quality = GetEquipmentQualityConfig.Call(equipment.Quality)[0] as LuaTable;

        // Icon先不写
        Name.GetComponent<TMPro.TextMeshProUGUI>().text = equipment.Name;
        ColorUtility.TryParseHtmlString(quality.Get<string>("Color"), out Color color);
        Name.GetComponent<TMPro.TextMeshProUGUI>().color = color;
        BackGroundImage.GetComponent<UnityEngine.UI.Image>().color = color;
        Quality.GetComponent<TMPro.TextMeshProUGUI>().text = quality.Get<string>("Name");

        // 先清空
        for (int i = 0; i < 3; i++)
        {
            OriginalModifiers[i].GetComponent<TMPro.TextMeshProUGUI>().text = "";
            PrefixSlots[i].GetComponent<TMPro.TextMeshProUGUI>().text = "";
            SuffixSlots[i].GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }

        for (int i = 0; i < equipment.Quality; i++)
        {
            LuaTable originalModifierConfig = GetModifiersConfig.Call(equipment.OriginalModifiers[i])[0] as LuaTable;
            LuaTable prefixModifierConfig = GetModifiersConfig.Call(equipment.Prefixs[i])[0] as LuaTable;
            LuaTable suffixModifierConfig = GetModifiersConfig.Call(equipment.Suffixs[i])[0] as LuaTable;

            // 这里仅仅是设置了名字，后续可以考虑加上数值和符号
            OriginalModifiers[i].GetComponent<TMPro.TextMeshProUGUI>().text = originalModifierConfig.Get<string>("Name");
            PrefixSlots[i].GetComponent<TMPro.TextMeshProUGUI>().text = prefixModifierConfig.Get<string>("Name");
            SuffixSlots[i].GetComponent<TMPro.TextMeshProUGUI>().text = suffixModifierConfig.Get<string>("Name");
        }

        if (equipment.Quality == 4)
        {
            LuaTable godfixModifierConfig = GetModifiersConfig.Call(equipment.Godfixs)[0] as LuaTable;
            GodfixSlot.GetComponent<TMPro.TextMeshProUGUI>().text = godfixModifierConfig.Get<string>("Name");
        }
        else
        {
            GodfixSlot.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }
}
