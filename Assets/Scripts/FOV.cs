using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float fov = 90f;
        int rayCount = 2;
        float angle = 0f;
        float deltaAngle = fov / rayCount;
        float viewDistance = 4f;
        
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
