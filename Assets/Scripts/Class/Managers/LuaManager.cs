using System.IO;
using UnityEngine;
using XLua;

namespace TowerDefenseAdventureLegends.Assets.Scripts.Class.Managers
{
    public class LuaManager
    {
        private LuaEnv luaEnv;

        public LuaManager()
        {
            Initialized();
        }

        private void Initialized()
        {
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(CustomLoader);
        }

        public void LoadConfigScript(string scriptName)
        {
            luaEnv.DoString($"require '{scriptName}'");
        }

        public LuaFunction GetFunction(string functionName)
        {
            return luaEnv.Global.Get<LuaFunction>($"{functionName}");
        }

        public void Destroy()
        {
            luaEnv.Dispose();
        }

        /// <summary>
        /// �Զ��� loader ���ڼ��� Lua �ļ�
        /// </summary>
        /// <param name="filepath">·��</param>
        /// <returns></returns>
        public byte[] CustomLoader(ref string filepath)
        {
            string luaPath = Path.Combine(Application.dataPath, "Resources", filepath + ".lua");

            if (File.Exists(luaPath))
            {
                Debug.Log($"�ɹ����� Lua �ļ�: {luaPath}");
                return File.ReadAllBytes(luaPath);
            }
            else
            {
                Debug.LogError($"Lua �ļ�δ�ҵ�: {luaPath}");
                return null;
            }
        }
    }
}
