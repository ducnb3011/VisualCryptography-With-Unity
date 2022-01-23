using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunctionManager : MonoBehaviour
{
    public GameObject RootMap;
    public GameObject Share1;
    public GameObject Share2;
    public float timeAvalable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnCrypt()
    {
        Collider[] hitColliders1 = Physics.OverlapSphere(Share1.transform.position, 2f);
        for (int i = 0; i < hitColliders1.Length; i++)
        {
            if(hitColliders1[i].GetComponent<PixelMap>() != null)
            {
                Destroy(hitColliders1[i],0f);
                hitColliders1[i].gameObject.SetActive(false);
            }
        }
        Collider[] hitColliders2 = Physics.OverlapSphere(Share2.transform.position, 2f);
        for (int i = 0; i < hitColliders2.Length; i++)
        {
            if (hitColliders2[i].GetComponent<PixelMap>() != null)
            {
                Destroy(hitColliders2[i],0f);
                hitColliders2[i].gameObject.SetActive(false);
            }
        }

        // Flip the coin then EnCrypt
        int coinFlip = Random.Range(0, 2);

        // Create Share 1
        GameObject Share1Map = Instantiate(RootMap, Share1.transform.position, Share1.transform.rotation);
        Share1Map.tag = Share1.tag;
        Share1Map.layer = Share1.layer;
        Share1Map.GetComponent<PixelMap>().SetShare(1);
        Share1Map.GetComponent<PixelMap>().EncryptShare(coinFlip);
        Share1Map.GetComponent<Collider>().enabled = true;
        
        // Create Share 2
        GameObject Share2Map = Instantiate(RootMap, Share2.transform.position, Share2.transform.rotation);
        Share2Map.tag = Share2.tag;
        Share2Map.layer = Share2.layer;
        Share2Map.GetComponent<PixelMap>().SetShare(2);
        Share2Map.GetComponent<PixelMap>().EncryptShare(coinFlip);
        Share2Map.GetComponent<Collider>().enabled = true;

        Destroy(Share1Map, timeAvalable);
        Destroy(Share2Map, timeAvalable);
    }
    public void ReadTimeInput(Text inputText)
    {
        timeAvalable = float.Parse(inputText.text);
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Share1.transform.position, 2);
        Gizmos.DrawWireSphere(Share2.transform.position, 2);
    }
}
