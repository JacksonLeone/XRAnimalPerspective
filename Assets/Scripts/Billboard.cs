using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Animator anim;
    public Transform player;
    public float distance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);

        float xd = Vector3.Distance(player.position, transform.position);
        Debug.Log("DISTANCE: " + xd);
        Debug.Log("ds: " + distance);

        if (xd < distance)
        {
            anim.SetBool("close", true);
        } else
        {
            anim.SetBool("close", false);
        }
    }
}
