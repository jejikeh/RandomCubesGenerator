using UnityEngine;

class CellBase
{
    //private int _value; Some time i will use them, i swear
    //private Vector3 _position;
    private Cell _cellObject;

    /*
        
        CellBase -
        surprisingly, this constructor calls a method, 
        which in turn also calls a method, 
        which in turn creates a game object, 
        puts the necessary(or not so) coordinates to it and returns the created object,
        which we later save in the field
        
    */

    public CellBase(Vector3 position,Transform parentTransform,Cell cellPrefab,GridManager.CellState cellState)
    {
        //_value = value;
        //_position = position;
        SetCellObject(position,parentTransform,cellPrefab,cellState);
    }

    private void SetCellObject(Vector3 position,Transform parentTransform,Cell cellPrefab,GridManager.CellState cellState)
    {
        _cellObject = cellPrefab.CreateCellObject(position,parentTransform,cellPrefab,cellState);
    }

    public void ClearCellOject()
    {
        _cellObject.DestroyCellObject();
    }

    public void SetCellObjectState(GridManager.CellState cellState)
    {
        
    }
}
