using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlaceholder : MonoBehaviour
{
    public int pieceToFitID;
    [SerializeField] private bool pieceOnRightPlace = false;
    [SerializeField] private Collider2D pieceCollider;
    [SerializeField] private PuzzleManager puzzleManager;
    public bool PieceOnRightPlace
    {
        get => pieceOnRightPlace;
        set
        {
            pieceOnRightPlace = value;
            if(pieceOnRightPlace)
            {
                OnPieceBeenFit?.Invoke(pieceOnRightPlace);
            }
        }
    }

    public delegate void PieceBeenFitEvent(bool rightFit);
    public static event PieceBeenFitEvent OnPieceBeenFit;

    public delegate void RightPieceLeftPlaceholder();
    public static event RightPieceLeftPlaceholder OnRightPieceLeftPlaceholder;

    private void OnEnable()
    {
        pieceCollider.enabled = true;
    }
    private void OnDisable()
    {
        pieceCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var puzzlePiece = other.gameObject.GetComponent<PuzzlePiece>();
        if(puzzlePiece != null)
        {
            PieceOnRightPlace = puzzlePiece.pieceID == pieceToFitID;
            if(PieceOnRightPlace)
            {
                var piece = other.transform.parent;
                piece.transform.localPosition = transform.localPosition;
                var draggableScript = other.transform.parent.GetComponent<DraggableObject>();
                draggableScript.isActive = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (puzzleManager.puzzleIsRight) return;

        var puzzlePiece = other.gameObject.GetComponent<PuzzlePiece>();

        if (puzzlePiece == null) return;

        if (puzzlePiece.pieceID == pieceToFitID)
        {
            PieceOnRightPlace = false;
            OnRightPieceLeftPlaceholder?.Invoke();
        }
    }
}
