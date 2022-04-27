using UnityEngine;

public class Cell : MonoBehaviour
{

    /*

        CreateCellObject - 
        I do not know what this method does, 
        but I can say for sure that it does NOT create an object, 
        and even more so it does NOT return it!
    
    */

    public Cell CreateCellObject(Vector3 position,Transform parentTransform,Cell cellPrefab)
    {
        GameObject cellObject = Instantiate(cellPrefab.gameObject);
        cellObject.transform.position = position;

        cellObject.name = ToString(); // Keeps the editor tidy and clean
        cellObject.transform.SetParent(parentTransform, true); // Keeps the editor tidy and clean


        return cellObject.GetComponent<Cell>();
    }

    public void DestroyCellObject()
    {
        Destroy(gameObject);
    }

    public void SetCellState(GridManager.CellState cellState)
    {
        gameObject.GetComponent<Renderer>().material.color = cellState.CellColor;
    }

}
