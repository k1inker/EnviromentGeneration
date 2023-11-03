using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainGeneration : MonoBehaviour
{

    [Header("Parametrs Terrain")]
    [Range(5f,20f),SerializeField] private float _scaleNoise = 10f;
    [SerializeField] private Gradient _gradient;
    [field: SerializeField] public int ySize { get; private set; } = 6;
    [field: SerializeField] public int xSize { get; private set; } = 40;
    [field: SerializeField] public int zSize { get; private set; } = 40;

    private Mesh _mesh;
    private void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        UpdateMesh();
    }
    public void SetSize(int size)
    {
        xSize = size;
        zSize = size;
        HandlerTerrain.CreateShape(xSize, zSize, _scaleNoise, ySize);
        UpdateMesh();
    }
    public void SetScaleNoise(float value)
    {
        _scaleNoise = value;
        HandlerTerrain.CreateShape(xSize, zSize, _scaleNoise, ySize);
        UpdateMesh();
    }
    public void SetHeight(int value)
    {
        ySize = value;
        HandlerTerrain.CreateShape(xSize, zSize, _scaleNoise, ySize);
        UpdateMesh();
    }
    private void UpdateMesh()
    {
        HandlerTerrain.CreateShape(xSize, zSize, _scaleNoise, ySize);
        _mesh.Clear();

        _mesh.vertices = HandlerTerrain.GetVertices();
        _mesh.triangles = HandlerTerrain.GetTriangles();
        HandlerTerrain.CreateShape(xSize, zSize, _scaleNoise, ySize);
        _mesh.colors = ColorTerrain.GetColors(xSize, zSize, _gradient);

        _mesh.RecalculateBounds();
    }
}
