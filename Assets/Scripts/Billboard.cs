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
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        float xd = Vector3.Distance(player.position, transform.position);

        if (xd < distance)
        {
            anim.SetBool("close", true);
        } else
        {
            anim.SetBool("close", false);
        }
    }
}
