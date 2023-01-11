using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject currentTurrent;

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(currentTurrent != null)
        {
            Debug.Log("This can't be built there - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.buildManager.getTurretToBuild();
        currentTurrent = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
