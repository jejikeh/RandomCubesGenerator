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
    public void FillGrid(Vector3 size,float gap,Transform transform, Cell cellPrefab,GridManager.CellState cellState,Vector2 randomOffset)
    {

        ClearGrid(); // If grid allready created - delete all cells


        for (int x = 0; x < size.x; x++) // filling 3d list
        {
            List<List<CellBase>> grid_xy = new List<List<CellBase>>(); // temp 2d list 
            for (int y = 0; y < size.y; y++)
            {
                List<CellBase> grid_x = new List<CellBase>(); // temp list of cells
                for (int z = 0; z < size.z; z++)
                {
                    // add cell to list with CellBase class constructor
                    grid_x.Add(new CellBase(new Vector3(x + (gap * x) + transform.position.x + Random.Range(randomOffset.x,randomOffset.y), y + (gap * y) + transform.position.y + Random.Range(randomOffset.x, randomOffset.y), z + (gap * z) + transform.position.z + Random.Range(randomOffset.x, randomOffset.y)), transform, cellPrefab,cellState));
                }

                grid_xy.Add(grid_x);
            }
            Grid_xyz.Add(grid_xy);
        }

        //SetCellsState(defaultState); // Spawn object unset by default
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

    public void SetCellsState(GridManager.CellState cellState)
    {
        foreach (List<List<CellBase>> grid_xy in Grid_xyz)
        {
            foreach (List<CellBase> grid_x in grid_xy)
            {
                foreach (CellBase cell in grid_x)
                {
                    cell.SetCellObjectState(cellState);
                }
            }
        }
    }

    public void SetCellState(GridManager.CellState cellState, Vector3Int index)
    {
        if(index.z < Grid_xyz.Count && index.y < Grid_xyz[index.z].Count && index.x < Grid_xyz[index.z][index.y].Count)
        {
            Grid_xyz[index.z][index.y][index.x].SetCellObjectState(cellState);
        }
    }

    public void SetCellState(GridManager.CellState cellState)
    {
        int randomX_Index = Random.Range(0, Grid_xyz.Count-1);
        int randomY_Index = Random.Range(0, Grid_xyz[randomX_Index].Count);
        int randomZ_Index = Random.Range(0, Grid_xyz[randomX_Index][randomY_Index].Count);


        Vector3Int randomIndex = new Vector3Int(randomX_Index, randomY_Index, randomZ_Index);
        Debug.Log(randomIndex);
        Grid_xyz[randomIndex.x][randomIndex.y][randomIndex.z].SetCellObjectState(cellState);
    }
}
