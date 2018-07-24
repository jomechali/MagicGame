using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class WeightedTiles : Tile 
{
	public int weight = 0;
#if UNITY_EDITOR
	[MenuItem("Assets/Create/Tiles/WeightedTile")]
	public static void CreatedWieghtedTileAsset()
	{
		string path = EditorUtility.SaveFilePanelInProject ("Save weighted tile", "New Weighted Tile", "asset", "Save Weighted Tile");
		AssetDatabase.CreateAsset (ScriptableObject.CreateInstance<WeightedTiles>(), path);
	}
#endif
}
