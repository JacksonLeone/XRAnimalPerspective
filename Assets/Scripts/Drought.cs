using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drought : MonoBehaviour
{
    public GameObject player;
    public Material dirt;
    public Terrain terr;
    public GameObject rain;
    public GameObject water;
    public AudioSource player_audio;
    public AudioClip voice;

    private bool enter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
            terr.materialTemplate = dirt;
            rain.SetActive(false);
            water.SetActive(false);

            if (!enter)
            {
                player_audio.PlayOneShot(voice);
                enter = true;
            }
        } else
        {
            enter = false;
        }
    }
}
