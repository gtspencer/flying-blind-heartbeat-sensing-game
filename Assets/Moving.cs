using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    public bool move;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += Vector3.left * speed * Time.deltaTime * -1;
        }
    }

    public void StartMove()
    {
        move = true;
    }
}
