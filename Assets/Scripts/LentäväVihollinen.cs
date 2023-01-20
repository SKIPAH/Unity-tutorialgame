using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LentäväVihollinen : MonoBehaviour
{
    public float hoverPower;
    public float hoverHeight;

    private Rigidbody flyingRB;
   
    
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverPower;
            flyingRB.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

    }
}
