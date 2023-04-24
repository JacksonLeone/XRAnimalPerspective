using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logging : MonoBehaviour
{
    public GameObject player;
    public Terrain terr;
    public GameObject stump;
    public AudioSource audio;
    public AudioClip wind;
    public AudioSource player_audio;
    public AudioClip voice;

    private TreeInstance[] trees;
    private bool enter;

    // Start is called before the first frame update
    void Start()
    {
        trees = terr.terrainData.treeInstances;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
            audio.Pause();
            audio.clip = wind;
            audio.Play();
            audio.volume = 0.2f;

            if (!enter)
            {
                player_audio.Stop();
                player_audio.PlayOneShot(voice);
                enter = true;
            }
            
            foreach (TreeInstance tree in terr.terrainData.treeInstances)
            {
                Vector3 worldTreePos = Vector3.Scale(tree.position, terr.terrainData.size) + Terrain.activeTerrain.transform.position;
                Instantiate(stump, worldTreePos, Quaternion.identity);
            }
            List<TreeInstance> newTrees = new List<TreeInstance>(0);
            terr.terrainData.treeInstances = newTrees.ToArray();
        } else
        {
            enter = false;
        }
        
    }

    void OnApplicationQuit()
    {
        terr.terrainData.treeInstances = trees;
    }
}
