using System.Collections;
using System.Collections.Generic;
using TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class 武器面板显示测试 : MonoBehaviour
{
    public GameObject equipmentInformationPanelPrefab;
    private GameObject equipmentInformationPanel;
    private GameObject equipmentInformationPanelManager;
    private LuaManager luaManager;

    void Start()
    {
        equipmentInformationPanel = Instantiate(equipmentInformationPanelPrefab);
        equipmentInformationPanelManager = equipmentInformationPanel.transform.Find("Manager").GameObject();
        luaManager = new LuaManager();
    }

    void Update()
    {
        
    }

    public void Set()
    {
        Equipment equipment =  new Equipment() 
        { 
            Name = "测试武器",
            Quality = 3,
            OriginalModifiers = new int[] { 1, 2, 3 },
            Prefixs = new int[] { 1, 2, 3 },
            Suffixs = new int[] { 1, 2, 3 },
        };
        equipmentInformationPanelManager.GetComponent<EquipmentInformationPanelManager>().SetPanelData(equipment, luaManager);
    }

    public void Clean()
    {
        Equipment equipment = new Equipment()
        {
            Name = "",
            Quality = 0,
            OriginalModifiers = new int[] { -1, -1, -1 },
            Prefixs = new int[] { -1, -1, -1 },
            Suffixs = new int[] { -1, -1, -1 },
            Godfixs = -1
        };
        equipmentInformationPanelManager.GetComponent<EquipmentInformationPanelManager>().SetPanelData(equipment, luaManager);
    }

    public void Show()
    {
        equipmentInformationPanelManager.GetComponent<EquipmentInformationPanelManager>().ShowPanel();
    }

    public void Hide()
    {
        equipmentInformationPanelManager.GetComponent<EquipmentInformationPanelManager>().HidePanel();
    }

    private void OnDestroy()
    {
        luaManager.Destroy();
    }
}
