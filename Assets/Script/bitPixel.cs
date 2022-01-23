using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitPixel : MonoBehaviour
{
    public bool bitSelect;


    public void SetBitSelect(bool select)
    {
        bitSelect = select;
    }
    public bool GetBitSelect()
    {
        return bitSelect;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bitSelect)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }

        Collider[] hitBitPixels = Physics.OverlapSphere(transform.position, 0.1f);
        
        for (int i = 0; i < hitBitPixels.Length; i++)
        {
            if (hitBitPixels[i].GetComponent<bitPixel>() != null && hitBitPixels[i].gameObject != gameObject && hitBitPixels[i].gameObject.tag != gameObject.tag)
            {
                if(hitBitPixels[i].GetComponent<bitPixel>().GetBitSelect() == GetComponent<bitPixel>().GetBitSelect())
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.black;
                }
                return;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
