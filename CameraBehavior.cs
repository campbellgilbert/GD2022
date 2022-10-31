using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3(20f, 0f, 0f);
    private Transform target;
     
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        this.transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 40);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y + 6, target.position.z - 40);
        this.transform.LookAt(target);
    }
}
