using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector3(target.forward.x,0,target.forward.z);
        transform.rotation= Quaternion.LookRotation(direction, Vector3.up);
    }
}
