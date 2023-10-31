using System;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{

    [Header("Parametrs Terrain")]
    [SerializeField] private int _xSize = 40;
    [SerializeField] private int _zSize = 40;
    [SerializeField] private float _scaleY = 2f;
    [Range(5f,20f),SerializeField] private float _scaleNoise = 10f;
    [SerializeField] private Gradient _gradient;

    private Mesh _mesh;
    private void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
    }
    public void SetSize(int size)
    {
        _xSize = size;
        _zSize = size;
    }
    public void SetScaleNoise(float value)
    {
        _scaleNoise = value;
    }
    public void SetHeight(float value)
    {
        _scaleY = value;
    }
    private void Update()
    {
        HandlerTerrain.CreateShape(_xSize,_zSize,_scaleNoise,_scaleY);
        UpdateMesh();
    }
    private void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = HandlerTerrain.GetVertices();
        _mesh.triangles = HandlerTerrain.GetTriangles();
        _mesh.colors = ColorTerrain.GetColors(_xSize, _zSize, _gradient);

        _mesh.RecalculateBounds();
    }
}
