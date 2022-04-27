using System.Collections.Generic;
using UnityEngine;

class GridBase
{
    public List<List<List<CellBase>>> Grid_xyz; // wow, 3d list 

    public GridBase()
    {
        Grid_xyz = new List<List<List<CellBase>>>();
        // FillGrid() - You can call FillGrid in the constructor, but I like to call the method separately
    }

    /*

        FillGrid - 
        initializes a 3d list and creates game objects at the specified coordinates.
        Before that, deletes all objects in the array.

    */
    public void FillGrid(Vector3 size,float gap,Transform transform, Cell cellPrefab)
    {

        ClearGrid(); // If grid allready created - delete all cells


        for (int z = 0; z < size.z; z++) // filling 3d list
        {
            List<List<CellBase>> grid_xy = new List<List<CellBase>>(); // temp 2d list 
            for (int y = 0; y < size.y; y++)
            {
                List<CellBase> grid_x = new List<CellBase>(); // temp list of cells
                for (int x = 0; x < size.x; x++)
                {
                    // add cell to list with CellBase class constructor
                    grid_x.Add(new CellBase(0, new Vector3(x + (gap * x) + transform.position.x, y + (gap * y) + transform.position.y, z + (gap * z) + transform.position.z),transform,cellPrefab));
                }

                grid_xy.Add(grid_x);
            }
            Grid_xyz.Add(grid_xy);
        }
    }

    public void ClearGrid() // delete every game object in a 3d list
    {
        foreach (List<List<CellBase>> grid_xy in Grid_xyz)
        {
            foreach (List<CellBase> grid_x in grid_xy)
            {
                foreach (CellBase cell in grid_x)
                {
                    cell.ClearCellOject();
                }
            }
        }

        Grid_xyz.Clear(); // Clear 3d list
    }
}
