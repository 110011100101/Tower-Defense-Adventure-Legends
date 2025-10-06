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
        /// 自定义 loader 用于加载 Lua 文件
        /// </summary>
        /// <param name="filepath">路径</param>
        /// <returns></returns>
        public byte[] CustomLoader(ref string filepath)
        {
            string luaPath = Path.Combine(Application.dataPath, "Resources", filepath + ".lua");

            if (File.Exists(luaPath))
            {
                Debug.Log($"成功加载 Lua 文件: {luaPath}");
                return File.ReadAllBytes(luaPath);
            }
            else
            {
                Debug.LogError($"Lua 文件未找到: {luaPath}");
                return null;
            }
        }
    }
}
