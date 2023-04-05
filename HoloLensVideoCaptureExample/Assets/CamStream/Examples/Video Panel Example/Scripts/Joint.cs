using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public GameObject JointObject;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPointer(Vector3 v1)
    {
        v1.y = v1.y * -1;
        Debug.Log("before:  " + v1);
        JointObject.transform.position = v1;
        Debug.Log("after:  " + JointObject.transform.position);
    }

}
