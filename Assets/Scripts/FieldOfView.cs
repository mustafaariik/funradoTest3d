using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float angle;
    [SerializeField] Color meshColor = Color.red;

    Mesh mesh;

    Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = segments * 4;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 center = Vector3.zero;
        Vector3 right = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 left = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        float currentAngle = -angle;
        float deltaAngle = -angle * 2 / segments;

        for(int i = 0; i < segments; i++)
        {
            right = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
            left = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance;
            currentAngle += deltaAngle;

            vertices[0] = center;
            vertices[1] = right;
            vertices[2] = left;
        }

        

        for(int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

   
    private void OnValidate()
    {
        mesh = CreateMesh();
    }

    
    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }
    
    
    
}
