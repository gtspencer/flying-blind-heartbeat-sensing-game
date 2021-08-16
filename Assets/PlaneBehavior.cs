using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    public bool up;
    public bool down;
    public GameObject planeSystem;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            up = false;
            if (this.transform.position.y <= 4)
            {
                planeSystem.transform.position += Vector3.up * speed * Time.deltaTime;
            }
        } else if (down)
        {
            down = false;
            if (this.transform.position.y >= 0)
            {
                planeSystem.transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }

    public void sendUp()
    {
        up = true;
    }

    public void sendDown()
    {
        down = true;
    }
}
