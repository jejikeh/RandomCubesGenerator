using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CellTemplate
{
    private int _value;
    public int Value { get { return _value; }}
    public Cell CellObject;

    private Vector3 _position;
    public Vector3 Position { get { return _position; } }

    public CellTemplate(int value, Vector3 position)
    {
        _value = value;
        _position = position;
    }

    public void SetObject(Cell cellObject)
    {
        CellObject = cellObject;
    }

    public void DestroyObject()
    {
        
        CellObject.DestroyCell();
    }

}

public class Cell : MonoBehaviour
{
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void DestroyCell()
    {
        Destroy(this.gameObject);
    }
}
