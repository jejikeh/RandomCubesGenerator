using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IE_Fill3DList 
{

    // COURUTINES !!!!!!! wow wowowow
    // Iterate in x,y,z.
    // First of all fill in z, after in y and x.
    public static IEnumerator FillGrid_xyz(List<List<List<CellBase>>> grid_xyz,Vector3 size, float gap, Transform transform, Cell cellPrefab, GridManager.CellState cellState, Vector2 randomOffset)
    {
        // maybe a bad code, but im okay with it
        for(int x = 0; x < size.x; x++)
        {
            List<List<CellBase>> grid_yz = new List<List<CellBase>>();
            Debug.Log(x);
            yield return FillGrid_yz(x,grid_yz,size,gap, transform,cellPrefab,cellState,randomOffset);
            grid_xyz.Add(grid_yz);
            //yield return new WaitForSeconds(0.1f);
        }
    }
    private static IEnumerator FillGrid_yz(int x, List<List<CellBase>> grid_yz, Vector3 size, float gap, Transform transform, Cell cellPrefab, GridManager.CellState cellState, Vector2 randomOffset)
    {
        for(int y = 0; y < size.y; y++)
        { 
            List<CellBase> grid_z = new List<CellBase>();
            yield return FillGrid_z(x,y,grid_z,size,gap, transform,cellPrefab,cellState,randomOffset);
            grid_yz.Add(grid_z);
            //yield return new WaitForSeconds(0.1f);

        }
    }

    private static IEnumerator FillGrid_z(int x,int y, List<CellBase> grid_z, Vector3 size, float gap, Transform transform, Cell cellPrefab, GridManager.CellState cellState, Vector2 randomOffset)
    {
        for(int z = 0; z < size.z; z++)
        {
            grid_z.Add(new CellBase(new Vector3(x + (gap * x) + transform.position.x + Random.Range(randomOffset.x, randomOffset.y), y + (gap * y) + transform.position.y + Random.Range(randomOffset.x, randomOffset.y), z + (gap * z) + transform.position.z + Random.Range(randomOffset.x, randomOffset.y)), transform, cellPrefab, cellState));
            yield return null;
            yield return new WaitForSeconds(0.01f);

        }

    }
}
