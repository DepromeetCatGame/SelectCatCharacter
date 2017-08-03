using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterManager : MonoBehaviour {
    enum indexes { CATIMG_START=0, CATIMG1=1, CATIMG2, CATIMG3, CATIMG_END};
    private indexes nIndex = indexes.CATIMG1;
    public string imgName;
    public int Status = 1;

    public int LeftTurn()
    {
        nIndex--;
        if (nIndex == indexes.CATIMG_START)
            nIndex = indexes.CATIMG_END-1;

        Status = 1;
        return (int)nIndex;
    }

    public int RightTurn()
    {
        nIndex++;
        if (nIndex == indexes.CATIMG_END)
            nIndex = indexes.CATIMG_START+1;

        Status = 1;
        return (int)nIndex;
    }

	// Use this for initialization
	void Start () {   }
	
	// Update is called once per frame
	void Update () {   }
    
    public Texture LoadPNGTexture()
    {
        if (imgName == "") imgName = "catimg";
        string fname = imgName;
        fname += (int)nIndex;
        Debug.Log(fname);
        return Resources.Load(fname) as Texture;
    }
    /*
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {
        Sprite NewSprite = new Sprite();
        Texture2D SpriteTexture = LoadTexture(FilePath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

        return NewSprite;
    }
    */
    public Texture2D LoadTexture(string FilePath)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);
            if (Tex2D.LoadImage(FileData)) 
                return Tex2D;              
        }
        return null;
    }
}
