using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcheck : MonoBehaviour {

    public RenderTexture renterTexture;
    public float LigthLevel;
    void Update () {
        RenderTexture temp = RenderTexture.GetTemporary(renterTexture.width, renterTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        Graphics.Blit(renterTexture, temp);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = temp;

        Texture2D temp2DTexture = new Texture2D(renterTexture.width, renterTexture.height);
        temp2DTexture.ReadPixels(new Rect(0, 0, temp.width, temp.height),0, 0);
        temp2DTexture.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(temp);

        Color32[] colors = temp2DTexture.GetPixels32();

        LigthLevel = 0;
        for(int i = 0; i < colors.Length; i++)
        {
            LigthLevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f * colors[i].b);
        }
        Debug.Log(LigthLevel);
    }
}
