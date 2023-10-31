using UnityEngine;

public static class HandlerTerrain
{
    private static Vector3[] _vertices;
    private static int[] _triangles;

    private static float _maxTerrainHeight;
    private static float _minTerrainHeight;
    public static void CreateShape(int xSize, int zSize, float scaleNoise, float scaleY)
    {
        CreateVertices(xSize, zSize, scaleNoise, scaleY);
        CreateTriangles(xSize, zSize);
    }
    private static void CreateTriangles(int xSize, int zSize)
    {
        _triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (float z = 0; z < zSize; z++)
        {
            for (float x = 0; x < xSize; x++)
            {
                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + xSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + xSize + 1;
                _triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }
    private static void CreateVertices(int xSize, int zSize, float scaleNoise, float scaleY)
    {
        _vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * (1 / scaleNoise), z * (1 / scaleNoise)) * scaleY;
                _vertices[i] = new Vector3(x, y, z);

                SetAmplitudeHeight(y);

                i++;
            }
        }
    }
    private static void SetAmplitudeHeight(float y)
    {
        if (y > _maxTerrainHeight)
            _maxTerrainHeight = y;
        if (y < _minTerrainHeight)
            _minTerrainHeight = y;
    }
    public static Vector3[] GetVertices()
    {
        return _vertices;
    }
    public static int[] GetTriangles()
    {
        return _triangles;
    }
    public static float GetMaxHeight()
    {
        return _maxTerrainHeight;
    }
    public static float GetMinHeight()
    {
        return _minTerrainHeight;
    }
}
