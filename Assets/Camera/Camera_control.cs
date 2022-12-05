using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour
{

    public GameObject target;
    public float Xoffset, Yoffset, Zoffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(Xoffset, Yoffset, Zoffset);
        transform.LookAt(target.transform.position);
    }
}
