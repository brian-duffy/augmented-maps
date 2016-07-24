using UnityEngine;
using System.Collections;
using System.Globalization;

public class ChangeSat : MonoBehaviour
{
	public Texture2D[] TerrainTextures;
	public TerrainData terraindata;
	public Terrain terrain;
	internal SplatPrototype[] splatTextureonecopy;
	internal SplatPrototype[] splatTexturetwocopy;
	internal SplatPrototype[] splatTexturethreecopy;
	public string texturefile;
	private Vector3 tilesize;
	SplatPrototype[] splatTextureone;

	void Start(){
		CreateTerrainTwo (1);
		CreateTerrainThree (2);
		CreateTerrain (0);
	}
	
	public void CreateTerrain(int mapChoice){
			
			SplatPrototype[] splatTextureone = new SplatPrototype [TerrainTextures.Length];
			for (int i=0; i<TerrainTextures.Length; i++) {
				splatTextureone [i] = new SplatPrototype ();
				splatTextureone [i].texture = TerrainTextures [mapChoice];    //Sets the texture
				splatTextureone [i].tileSize = new Vector2 (612,802);
		//	Sets the size of the texture
			}

		splatTextureonecopy = splatTextureone;

		//terraindata.splatPrototypes = splatTextureone;
		//terraindata.RefreshPrototypes ();
	} 

	public void CreateTerrainTwo(int mapChoice){
		
		SplatPrototype[] splatTexturetwo = new SplatPrototype [TerrainTextures.Length];
		for (int i=0; i<TerrainTextures.Length; i++) {
			splatTexturetwo [i] = new SplatPrototype ();
			splatTexturetwo [i].texture = TerrainTextures [mapChoice];    //Sets the texture
			splatTexturetwo [i].tileSize = new Vector2 (612,802);    //Sets the size of the texture
		}
		//terraindata.splatPrototypes = splatTexturetwo;
		splatTexturetwocopy = splatTexturetwo;
		//terraindata.RefreshPrototypes ();
	}


	public void CreateTerrainThree(int mapChoice){
		
		SplatPrototype[] splatTexturethree = new SplatPrototype [TerrainTextures.Length];
		for (int i=0; i<TerrainTextures.Length; i++) {
			splatTexturethree [i] = new SplatPrototype ();
			splatTexturethree [i].texture = TerrainTextures [mapChoice];    //Sets the texture
			splatTexturethree [i].tileSize = new Vector2 (612,802);    //Sets the size of the texture
		}
		//terraindata.splatPrototypes = splatTexturethree;
		splatTexturethreecopy = splatTexturethree;
		//terraindata.RefreshPrototypes ();
	}


}