using UnityEngine;
using UnityEditor;

public class EditPrefab {
	
	[MenuItem("Prefab/Edit Prefabs")]
	private static void EditPrefabs() {

		AssetDatabase.StartAssetEditing();
		var prefabs = AssetDatabase.FindAssets("prefab t:Prefab", new string[] {"Assets/Prefabs"});
		foreach (var prefab in prefabs){
			var path = AssetDatabase.GUIDToAssetPath(prefab);
			var loaded = PrefabUtility.LoadPrefabContents(path);

			// change prefab here
			UnityEngine.Object.DestroyImmediate(loaded.GetComponent(typeof(Collider)));

			// unload
			PrefabUtility.SaveAsPrefabAsset(loaded, path);
			PrefabUtility.UnloadPrefabContents(loaded);
		}
		AssetDatabase.StopAssetEditing();
		AssetDatabase.SaveAssets();

		Debug.Log($"{prefabs.Length} items processed");
	}
}