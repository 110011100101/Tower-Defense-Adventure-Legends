using UnityEditor;
using UnityEngine;
using System.IO;

// ————————————————
// 版权声明：本文为CSDN博主「ThousandPine」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
// 原文链接：https://blog.csdn.net/ThousandPine/article/details/140421224
public class CreateAndRenameLuaScript : MonoBehaviour
{
    // 默认文件名
    private static readonly string FILE_NAME = "Config.lua.txt";
    // 脚本默认内容
    private static readonly string DEFAULT_CONTENT = "";

    [MenuItem("Assets/Create/创建 Lua 配置文件", false, 80)]
    public static void CreateNewLuaScript()
    {
        // 获取当前选中的对象的路径
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
        {
            path = "Assets/Resources/Configs";
        }
        // 如果选中的对象不是文件夹，则在其所在目录下创建Lua脚本
        else if (!AssetDatabase.IsValidFolder(path))
        {
            path = Path.GetDirectoryName(path);
        }

        // 设置新Lua脚本的完整路径和名称
        path = Path.Combine(path, FILE_NAME);
        string newFilePath = AssetDatabase.GenerateUniqueAssetPath(path);

        // 创建Asset
        ProjectWindowUtil.CreateAssetWithContent(newFilePath, DEFAULT_CONTENT);
    }
}
