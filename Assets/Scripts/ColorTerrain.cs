using UnityEngine;

public static class ColorTerrain
{
    private static Color[] _colors;
    public static Color[] GetColors(int xSize, int zSize, Gradient gradient)
    {
        Vector3[] vertices = HandlerTerrain.GetVertices();
        _colors = new Color[vertices.Length];

        float min = HandlerTerrain.GetMinHeight();
        float max = HandlerTerrain.GetMaxHeight();

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(min, max, vertices[i].y);
                _colors[i] = gradient.Evaluate(height);
                i++;
            }
        }
        return _colors;
    }
}
