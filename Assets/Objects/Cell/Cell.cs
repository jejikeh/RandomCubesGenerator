using UnityEngine;

public class Cell : MonoBehaviour
{

    private GridManager.CellState _cellState;
    /*

        CreateCellObject - 
        I do not know what this method does, 
        but I can say for sure that it does NOT create an object, 
        and even more so it does NOT return it!
    
    */


    public Cell CreateCellObject(Vector3 position,Transform parentTransform,Cell cellPrefab, GridManager.CellState cellState)
    {
        GameObject cellObject = Instantiate(cellPrefab.gameObject);
        cellObject.transform.position = position;
        _cellState = cellState;

        cellObject.name = ToString(); // Keeps the editor tidy and clean
        cellObject.transform.SetParent(parentTransform, true); // Keeps the editor tidy and clean



        return cellObject.GetComponent<Cell>();
    }


    public void DestroyCellObject()
    {
        Destroy(gameObject);
    }

    public void SetCellStateAnimation()
    {
        //gameObject.GetComponent<AnimationState>().clip = _cellState.AnimationState;
        gameObject.GetComponent<Animation>().Play();
    }

}
