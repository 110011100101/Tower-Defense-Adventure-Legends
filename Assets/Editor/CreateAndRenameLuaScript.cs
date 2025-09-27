using UnityEditor;
using UnityEngine;
using System.IO;

// ��������������������������������
// ��Ȩ����������ΪCSDN������ThousandPine����ԭ�����£���ѭCC 4.0 BY-SA��ȨЭ�飬ת���븽��ԭ�ĳ������Ӽ���������
// ԭ�����ӣ�https://blog.csdn.net/ThousandPine/article/details/140421224
public class CreateAndRenameLuaScript : MonoBehaviour
{
    // Ĭ���ļ���
    private static readonly string FILE_NAME = "Config.lua.txt";
    // �ű�Ĭ������
    private static readonly string DEFAULT_CONTENT = "";

    [MenuItem("Assets/Create/���� Lua �����ļ�", false, 80)]
    public static void CreateNewLuaScript()
    {
        // ��ȡ��ǰѡ�еĶ����·��
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
        {
            path = "Assets/Resources/Configs";
        }
        // ���ѡ�еĶ������ļ��У�����������Ŀ¼�´���Lua�ű�
        else if (!AssetDatabase.IsValidFolder(path))
        {
            path = Path.GetDirectoryName(path);
        }

        // ������Lua�ű�������·��������
        path = Path.Combine(path, FILE_NAME);
        string newFilePath = AssetDatabase.GenerateUniqueAssetPath(path);

        // ����Asset
        ProjectWindowUtil.CreateAssetWithContent(newFilePath, DEFAULT_CONTENT);
    }
}
