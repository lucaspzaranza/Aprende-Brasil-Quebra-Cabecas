using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStorager : MonoBehaviour
{
    public List<GameObject> pieces;
    public List<PiecePlaceholder> placeholders;
    public List<Vector2> piecesInitTransform;

    private void OnEnable()
    {
        if(piecesInitTransform.Count == 0)
            StoragePiecesPositions();
    }
    
    private void StoragePiecesPositions()
    {
        piecesInitTransform = new List<Vector2>(pieces.Count);

        foreach (var piece in pieces)
        {
            piecesInitTransform.Add(piece.transform.localPosition);
        }
    }

    public void RestorePiecesOriginalPosition()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].transform.localPosition = piecesInitTransform[i];
            pieces[i].GetComponent<DraggableObject>().isActive = true;
            placeholders[i].PieceOnRightPlace = false;
            GetComponent<PuzzleManager>().rightPiecesCounter = 0;
        }
    }
}
