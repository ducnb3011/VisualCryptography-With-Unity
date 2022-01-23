using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelMap : MonoBehaviour
{
    public GameObject[] pixels;

    public int share = 0;

    public void SetShare(int shareIndex)
    {
        share = shareIndex;
    }
    public int GetShare()
    {
        return share;
    }
    void Start()
    {
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(share != 0)
        {
            GetComponent<Collider>().enabled = true;
        }
    }
    public void EncryptShare(int flipCoin)
    {
        foreach(GameObject pixel in pixels)
        {
            pixel.GetComponent<Pixel>().Encode(flipCoin, share);
            pixel.GetComponent<Collider>().enabled = false;
        }
    }
}
