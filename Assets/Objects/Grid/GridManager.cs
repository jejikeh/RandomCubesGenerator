using UnityEngine;

public class GridManager : MonoBehaviour
{

    /* TODO :
        -- 1) Remake CellTemplate like GridBase.cs
        -- 2) Remove _size in GridBase.cs

        3) Clean some unused fileds
    */

    private GridBase _grid = new GridBase();
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private float _gap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 randomSize = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
            _grid.FillGrid(randomSize,_gap,transform,_cellPrefab.GetComponent<Cell>());
        }
    }
}
