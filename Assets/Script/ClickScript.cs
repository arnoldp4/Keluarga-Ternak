using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    Renderer rend;
    public Collider coll;
    public Color highlightColor;
    Color normalColor;
    void Start()
    {
        rend = GetComponent<Renderer> ();
        normalColor = rend.material.color;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if ( coll.Raycast(ray, out hitInfo, Mathf.Infinity) ){
            rend.material.color = highlightColor;

        } else {
            rend.material.color = normalColor;
        }
    }
}
