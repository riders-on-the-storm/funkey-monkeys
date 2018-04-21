using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRenderer : MonoBehaviour
{

	public Texture2D HeartTexture;
	public Texture2D HalfHeartTexture;
	public Texture2D EmptyHeartTexture;
	public int DistanceBetween;
	public int TextureWidth = 13;
	public int TextureHeight = 10;
	public int MaxHearth = 3;
	public int startX ;
	public int startY ;
	
	// Use this for initialization
	void Start () {
		
	}

	public void OnGUI()
	{
		int Health = GetComponent<MonkeyKeyController>().Health;
		int FullHearts = Health / 2;
		int col = 0;
		for (; col < FullHearts; col++) {
			GUI.DrawTexture(new Rect(startX + (DistanceBetween + TextureWidth)*col, startY, TextureWidth, TextureHeight), HeartTexture, ScaleMode.ScaleToFit);
		}
		int HalfHearts = Health % 2;
		for (int i = 0; i < HalfHearts; col++, i++) {
			GUI.DrawTexture(new Rect(startX + (DistanceBetween + TextureWidth)*col, startY, TextureWidth, TextureHeight), HalfHeartTexture, ScaleMode.ScaleToFit);
		}
		for (; col < MaxHearth; col++) {
			GUI.DrawTexture(new Rect(startX + (DistanceBetween + TextureWidth)*col, startY, TextureWidth, TextureHeight), EmptyHeartTexture, ScaleMode.ScaleToFit);
		}
	}
}
