using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers;
using TowerDefenseAdventureLegends.Assets.Scripts.Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class TabManager : MonoBehaviour
{
    public GameObject menuTabsObject;
    public GameObject containersObject;
    public GameObject tabPrefab;
    public GameObject containerPrefab;
    public ScriptableObject scripts;
    public Dictionary<GameObject, GameObject> tabs = new();

    void Start()
    {
        // ��lua�ű��л�ȡ���е�tab������
        var luaManager = new LuaManager();
        luaManager.LoadConfigScript("TabConfig");
        var tabCountResult = luaManager.GetFunction("GetTabCount").Call();
        int tabCount = tabCountResult != null && tabCountResult.Length > 0 ? Convert.ToInt32(tabCountResult[0]) : 0;

        for (int i = 0; i < tabCount; i++)
        {
            var tabResult = luaManager.GetFunction("GetTabConfig").Call(i);
            LuaTable tabConfig = tabResult != null && tabResult.Length > 0 ? tabResult[0] as LuaTable : null;
            if (tabConfig == null) continue;
            string name = tabConfig.Get<string>("Name");
            string scriptName = tabConfig.Get<string>("ScriptName");
            Type scriptType = Type.GetType($"TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers.{scriptName}");
            GameObject tab = Instantiate(tabPrefab, menuTabsObject.transform);
            GameObject container = Instantiate(containerPrefab, containersObject.transform);

            tabs.Add(tab, container);

            tab.name = name;
            tab.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = name;
            tab.GetComponent<Button>().onClick.AddListener(() => SwitchTab(tab));
            container.name = name;

            if (scriptType != null && typeof(IContainerManager).IsAssignableFrom(scriptType))
            {
                container.AddComponent(scriptType);
            }
        }

        SwitchTab(tabs.First().Key);

        luaManager.Destroy();
    }

    void Update()
    {

    }

    /// <summary>
    /// �л���ǩҳ. �������ͨ���ű��������tabs�ֵ���б���, ��ϳ̶Ⱥܸ�, ʹ��ʱ�����ȷ�˷��������õ�����
    /// </summary>
    /// <param name="tab"></param>
    public void SwitchTab(GameObject tab)
    {
        foreach (KeyValuePair<GameObject, GameObject> item in tabs)
        {
            if (item.Key != tab)
            {
                item.Value.SetActive(false);
            }
            else
            {
                item.Value.SetActive(true);
            }
        }
    }
}
