using System.IO;
using System.Text;
using UnityEditor;

namespace RuntimeTag.Editor
{
	class RuntimeTagGenerator
	{
		const string menuName = "Tools/Tag/Generate Runtime Tag";
		const int menuOrder = 100;

		const string path = "Assets/Plugins/Runtime/RuntimeTag_Part.cs";
		
		static string[] Tags
		{
			get
			{
				AssetDatabase.SaveAssets();
				return UnityEditorInternal.InternalEditorUtility.tags;
			}
		}

		[MenuItem(menuName, false, menuOrder)]
		static void Execute()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("public partial class RuntimeTag");
			sb.AppendLine("{");

			foreach (string tag in Tags)
			{
				sb.AppendLine($"	public const string {tag} = \"{tag}\";");
			}

			sb.AppendLine("}");
			
			File.WriteAllText(path, sb.ToString());
			AssetDatabase.ImportAsset(path);
			AssetDatabase.Refresh();
		}
	}
}