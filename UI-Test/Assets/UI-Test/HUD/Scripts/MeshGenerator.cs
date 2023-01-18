using System;
using UnityEngine;

public class MeshGenerator
{
    public static Mesh GenerateMesh(int resolution, float radius, float height, float chordAngle)
    {
        var mesh = new Mesh();

        var vertices = new Vector3[resolution * resolution];
        var triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        var triIndex = 0;
        var uv = (mesh.uv.Length == vertices.Length)?mesh.uv:new Vector2[vertices.Length];
        var angleStep = (float)((Math.PI / 180f) * chordAngle) / resolution;
        var heightStep = height / resolution;
        
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                var i = x + y * resolution;
                var angle = x * angleStep;
                
                var percent = new Vector2(x, y) / (resolution - 1);
                vertices[i] = new Vector3(radius * Mathf.Cos(angle), y * heightStep, radius * Mathf.Sin(angle));
                uv[i] = new Vector2(percent.x,percent.y);

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;
                    triIndex += 6;
                }
            }
        }
        
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uv;
        // mesh.hideFlags = HideFlags.HideAndDontSave;
        
        return mesh;
    }
}