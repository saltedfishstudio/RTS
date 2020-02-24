using UnityEngine;
using UnityEditor;

public class EditMultiTerrain
{
	[MenuItem("Tool/Multi terrain edit")]
	private static void SetDrawInstanced()
	{
		Terrain[] terrains = Selection.activeGameObject.GetComponentsInChildren<UnityEngine.Terrain>();
		foreach (var terrain in terrains)
		{
			// 여기에서 하고 싶은 작업
			terrain.drawInstanced = true;
			EditorUtility.SetDirty(terrain);
		}

		AssetDatabase.SaveAssets();
		Debug.Log($"Done. {terrains.Length} items.");
	}
}