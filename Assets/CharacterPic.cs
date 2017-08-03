using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPic : MonoBehaviour {
    public Texture myTexture;
    private int x, y, W,H;
    CharacterManager gmComponent;

    // Use this for initialization
    void Start () {
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //Renderer rend = go.GetComponent<Renderer>();
        //rend.material.mainTexture = Resources.Load("cat-icon") as Texture;
        gmComponent = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        myTexture = gmComponent.LoadPNGTexture();

        W = Screen.width / 2;
        H = Screen.height / 2;
        x = W / 2;
        y = H / 2;
        //Resources.Load("cat-icon");
    }
	
	// Update is called once per frame
	void Update () {
        if(gmComponent.Status == 1)
        {
            gmComponent.Status = 0;
            myTexture = gmComponent.LoadPNGTexture();
        }
	}

    private void OnGUI()
    {
        //Debug.Log("test");
        if (myTexture != null)
            GUI.DrawTexture(new Rect(x, y, W, H), myTexture);
        //else
        //    Debug.Log("cat image is missing");
    }
}
