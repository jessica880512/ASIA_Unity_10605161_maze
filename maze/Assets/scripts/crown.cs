using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown : MonoBehaviour
{
    [Range(1,100)]
    public int speed = 70;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   public void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 10, Space.World);
    }
}
