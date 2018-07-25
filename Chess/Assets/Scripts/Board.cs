using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// New
public enum CellState
{
    None,
    Friendly,
    Enemy,
    Free,
    OutOfBounds
}

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;

    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8];

    public void Create()
    {
        #region Create
        for(int i = 0; i < 8; i++)
        {
            for(int x = 0; x < 8; x++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);

                //position
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (i * 100) + 50);

                //Setup
                mAllCells[x, i] = newCell.GetComponent<Cell>();
                mAllCells[x, i].Setup(new Vector2Int(x, i), this);
            }
        }


        #region Color
        for(int x = 0; x < 8; x+=2)
        {
            for(int y = 0; y < 8; y++)
            {
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                //color
                mAllCells[finalX, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }
        }
        #endregion
    }
    #endregion

    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {   
        return CellState.Free;
    }
}
