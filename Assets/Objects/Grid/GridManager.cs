using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    /* TODO :
        1) Remake CellTemplate like GridBase

    */

    private GridBase _grid = new GridBase();
    [SerializeField] GameObject _cellPrefab;
    [SerializeField] float _gap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyCellObjects(_grid);
            _grid.FillGrid(new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10)),_gap);
            CreateCellObjects(_grid);
        }
    }

    private void CreateCellObjects(GridBase grid)
    {
        foreach (List<List<CellTemplate>> grid_xy in grid.Grid_xyz)
        {
            foreach (List<CellTemplate> grid_x in grid_xy)
            {
                foreach (CellTemplate cell in grid_x)
                {
                    GameObject cellObject = Instantiate(_cellPrefab);
                    cellObject.name = cell.ToString();
                    cellObject.GetComponent<Cell>().SetPosition(cell.Position);
                    cell.SetObject(cellObject.GetComponent<Cell>());
                }
            }
        }
    }
    private void DestroyCellObjects(GridBase grid)
    {
        foreach (List<List<CellTemplate>> grid_xy in grid.Grid_xyz)
        {
            foreach (List<CellTemplate> grid_x in grid_xy)
            {
                foreach (CellTemplate cell in grid_x)
                {
                    cell.DestroyObject();
                }
            }
        }
    }

}
