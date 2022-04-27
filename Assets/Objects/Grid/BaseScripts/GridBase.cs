using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GridBase
{
    public List<List<List<CellTemplate>>> Grid_xyz;
    private Vector3 _size;
    public Vector3 Size { get { return _size; } }

    public GridBase()
    {
        Grid_xyz = new List<List<List<CellTemplate>>>();
    }

    public void FillGrid(Vector3 size,float gap)
    {
        _size = size;
        Grid_xyz.Clear();
        Debug.Log(size);
        for (int z = 0; z < size.z; z++)
        {
            List<List<CellTemplate>> grid_xy = new List<List<CellTemplate>>();
            for (int y = 0; y < size.y; y++)
            {
                List<CellTemplate> grid_x = new List<CellTemplate>();
                for (int x = 0; x < size.x; x++)
                {
                    grid_x.Add(new CellTemplate(0, new Vector3(x + (gap * x), y + (gap * y), z + (gap * z))));
                }

                grid_xy.Add(grid_x);
            }
            Grid_xyz.Add(grid_xy);
        }
    }

    public void DebugPrintCells()
    {
        foreach (List<List<CellTemplate>> grid_xy in Grid_xyz)
        {
            foreach (List<CellTemplate> grid_x in grid_xy)
            {
                foreach (CellTemplate cell in grid_x)
                {
                    Debug.Log(cell.Value);
                }
            }
        }
    }
}
