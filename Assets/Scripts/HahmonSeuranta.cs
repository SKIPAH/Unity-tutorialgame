using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmonSeuranta : MonoBehaviour
{

    public Transform kohde;
    Vector3 et�isyys;
    // Start is called before the first frame update
    void Start()
    {
        et�isyys = transform.position - kohde.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = kohde.position + et�isyys;
    }
}
