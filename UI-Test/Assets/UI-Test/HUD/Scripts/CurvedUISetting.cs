using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CurvedUISetting : MonoBehaviour
{
    /// <summary>
    /// 弯曲半径
    /// </summary>
    [Header("弯曲半径")] 
    [Range(5, 100)] 
    public float CurveRadius = 20f;

    /// <summary>
    /// 分辨率，控制点和三角形的稀疏或密集程度
    /// </summary>
    [Header("分辨率")] 
    [Range(2, 512)] 
    public int MeshResolution = 10;

    /// <summary>
    /// 高度
    /// </summary>
    [Header("高度")]
    [Range(5, 100)] 
    public float Height = 30f;

    /// <summary>
    /// 用于渲染mesh的材质
    /// </summary>
    [Header("Curved Mesh材质")] 
    public Material CurveMaterial;

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private MeshGenerator _meshGenerator;

    private void Start()
    {
        Initialize();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        Initialize();
    }
#endif

    private void Initialize()
    {
        _meshRenderer = transform.GetOrAddComponent<MeshRenderer>();
        _meshRenderer.sharedMaterial = CurveMaterial;
        _meshFilter = transform.GetOrAddComponent<MeshFilter>();
        _meshFilter.sharedMesh = MeshGenerator.GenerateMesh(MeshResolution, CurveRadius, Height, 180f);
    }
}