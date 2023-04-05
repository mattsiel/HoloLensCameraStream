using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appendage : MonoBehaviour
{

    Vector3 appOffset = new Vector3(-4.6f, -1.6f, 8);
    // Update is called once per frame
    void Update()
    {
        //SetAll(cy1);
    }

    public void SetPosition(Vector3 v1, Vector3 v2)
    {
        appOffset = JointManager.Instance.offset;
        Debug.Log(appOffset);

        if((v1 == appOffset) || (v2 == appOffset)){
            Debug.Log("hiding: " + this.gameObject.name);
            this.gameObject.SetActive(false);
        }else {
            this.gameObject.SetActive(true);
        }

        v1.y = v1.y * -1;
        v2.y = v2.y * -1;
        if(v2.y < v1.y)
        {
            Vector3 temp = v2;
            v2 = v1;
            v1 = temp;
        }

        Vector3 difference = v2 - v1;
        Debug.Log(v2);
        Debug.Log(v1);

        Vector3 middle = v1 + difference / 2;
        Vector3 scale = difference;
        scale = new Vector3(Mathf.Abs(scale.x), Mathf.Abs(scale.y), Mathf.Abs(scale.z));

        // Vector3 normal = Vector3.Cross(v2,v1) / (Vector3.Cross(v2,v1)).magnitude;
        // float normal_ = Vector3.Cross(v2,v1).magnitude / Vector3.Dot(v2,v1);
        // float angle = Mathf.Atan(normal_);

        // Quaternion rot = new Quaternion(Mathf.Cos(angle/2), normal.x * Mathf.Sin(angle/2), normal.y * Mathf.Sin(angle/2), normal.z * Mathf.Sin(angle/2));
        // Debug.Log(rot);
        // cy.transform.rotation = rot;


        // cy.transform.rotation = Quaternion.FromToRotation(v2-v1, Vector3.up);

        float differenceY = v2.y - v1.y;
        float differenceX = v2.x - v1.x;
        float differenceZ = v2.z - v1.z;

        float magnitude = Mathf.Sqrt(Mathf.Pow(differenceX, 2f) + Mathf.Pow(differenceY, 2f) + Mathf.Pow(differenceZ, 2f));

        float ratioZoX = differenceZ / differenceX;
        float angleRotZ = Mathf.Rad2Deg * Mathf.Atan(ratioZoX);

        float ratioYoZ = -differenceY / differenceZ;
        float angleRotY = Mathf.Rad2Deg * Mathf.Atan(ratioYoZ);

        float ratioYoX = differenceY / differenceX;
        float angleRotX = Mathf.Rad2Deg * Mathf.Atan(ratioYoX);
        
        this.transform.rotation = Quaternion.Euler(angleRotX, angleRotY, 0);

        // Vector3 newDirection = Vector3.RotateTowards(v2, v1, 5, 0.0f);
        // cy.transform.rotation = Quaternion.LookRotation(newDirection);

        // scale
        Vector3 side1 = new Vector3(-scale.x, scale.y, 0);
        Vector3 side2 = new Vector3(-scale.x, 0, scale.z);
        var dir = Vector3.Cross(side1, side2);
        var norm = Vector3.Normalize(dir);

        this.transform.localScale = norm * magnitude + new Vector3(0.1f, 0.1f, 0.1f);
        this.transform.position = middle;

    }
}
