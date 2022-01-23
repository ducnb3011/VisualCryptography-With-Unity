using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public GameObject[] bitPixel;
    public bool isSelected = false;

    bool isShare = false;

    void Start()
    {
        foreach (GameObject bit in bitPixel)
        {
            bit.GetComponent<Collider>().enabled = false;
            bit.GetComponent<bitPixel>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShare)
        {
            foreach (GameObject bit in bitPixel)
            {
                bit.GetComponent<Collider>().enabled = true;
                bit.GetComponent<bitPixel>().enabled = true;
            }
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSelected)
            {
                //foreach (Transform child in transform)
                foreach (GameObject bit in bitPixel)
                {
                    bit.GetComponent<Renderer>().material.color = Color.black;
                }
            }
            else
            {
                foreach (GameObject bit in bitPixel)
                {
                    bit.GetComponent<Renderer>().material.color = Color.white;
                }
            }
            isSelected = !isSelected;
        }
    }
    public void Encode(int flipCoin, int share)
    {
        isShare = true;

        for (int i = 0; i < bitPixel.Length; i++)
        {
            bitPixel[i].GetComponent<Collider>().enabled = true;
            if(share == 1)
            {
                bitPixel[i].tag = "Share1";
                bitPixel[i].layer = 7;
            }
            if (share == 2)
            {
                bitPixel[i].tag = "Share2";
                bitPixel[i].layer = 6;
            }
        }
        if (isSelected)
        {
            if(flipCoin == 1)
            {
                if(share == 1)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[0].GetComponent<bitPixel>().SetBitSelect(true);
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[2].GetComponent<bitPixel>().SetBitSelect(true);

                    bitPixel[1].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.white;
                }
                else if (share == 2)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.white;

                    bitPixel[1].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[1].GetComponent<bitPixel>().SetBitSelect(true);
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[3].GetComponent<bitPixel>().SetBitSelect(true);
                }
            }
            else if (flipCoin == 0)
            {
                if (share == 2)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[0].GetComponent<bitPixel>().SetBitSelect(true);
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[2].GetComponent<bitPixel>().SetBitSelect(true);

                    bitPixel[1].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.white;
                }
                else if (share == 1)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.white;

                    bitPixel[1].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[1].GetComponent<bitPixel>().SetBitSelect(true);
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[3].GetComponent<bitPixel>().SetBitSelect(true);
                }
            }
        }
        else
        {
            if (flipCoin == 1)
            {
                bitPixel[0].GetComponent<Renderer>().material.color = Color.black;
                bitPixel[0].GetComponent<bitPixel>().SetBitSelect(true);
                bitPixel[2].GetComponent<Renderer>().material.color = Color.black;
                bitPixel[2].GetComponent<bitPixel>().SetBitSelect(true);

                bitPixel[1].GetComponent<Renderer>().material.color = Color.white;
                bitPixel[3].GetComponent<Renderer>().material.color = Color.white;
                /*
                else if (share == 2)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[1].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.white;
                }
                */
            }
            else if (flipCoin == 0)
            {
                bitPixel[0].GetComponent<Renderer>().material.color = Color.white;
                bitPixel[2].GetComponent<Renderer>().material.color = Color.white;

                bitPixel[1].GetComponent<Renderer>().material.color = Color.black;
                bitPixel[1].GetComponent<bitPixel>().SetBitSelect(true);
                bitPixel[3].GetComponent<Renderer>().material.color = Color.black;
                bitPixel[3].GetComponent<bitPixel>().SetBitSelect(true);

                /*
                else if (share == 1)
                {
                    bitPixel[0].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[2].GetComponent<Renderer>().material.color = Color.white;
                    bitPixel[1].GetComponent<Renderer>().material.color = Color.black;
                    bitPixel[3].GetComponent<Renderer>().material.color = Color.black;
                }
                */
            }
        }
        
    }
}
