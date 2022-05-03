using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour
{

    /* TODO :
        -- 1) Remake CellTemplate like GridBase.cs
        -- 2) Remove _size in GridBase.cs

        -- 3) Clean some unused fileds

        4) use now the animations to handle states
        5) rewrite camera script
        6) add smooth change target to camera
    */

    [System.Serializable]
    public class CellState
    {
        public AnimationClip AnimationState;
        public CellState(AnimationClip clip)
        {
            AnimationState = clip;
        }
    }

    [Header("Cell Settings")]
    [SerializeField] private CellState _unset;
    [SerializeField] private CellState _active;
    private GridBase _grid = new GridBase();
    [SerializeField] private GameObject _cellPrefab;


    [Header("Grid Settings")]
    [SerializeField] private float _gap;
    [SerializeField] private Vector2 _randomOffset;
    [SerializeField] private Vector2 _randomSize;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 randomSize = new Vector3(Random.Range(_randomSize.x, _randomSize.y), Random.Range(_randomSize.x, _randomSize.y), Random.Range(_randomSize.x, _randomSize.y));

            StopCoroutine(_grid.FillGrid(randomSize, _gap, transform, _cellPrefab.GetComponent<Cell>(), _unset, _randomOffset));
            StartCoroutine(_grid.FillGrid(randomSize,_gap,transform,_cellPrefab.GetComponent<Cell>(),_unset,_randomOffset));
            
            //_grid.SetCellState(_active);
        }
    }
}
