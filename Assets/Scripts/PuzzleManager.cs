using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int totalPieces;
    public int rightPiecesCounter;
    public bool puzzleIsRight;
    public AudioClip rightSFX;
    public AudioClip errorSFX;
    public AudioClip puzzleCompleteSFX;
    public GameObject doneBtn;
    private void OnEnable()
    {
        PiecePlaceholder.OnPieceBeenFit += HandlePieceFitEvent;
        PiecePlaceholder.OnRightPieceLeftPlaceholder += HandleRightPieceLeftPlaceholderEvent;
    }

    private void OnDisable()
    {
        PiecePlaceholder.OnPieceBeenFit -= HandlePieceFitEvent;
        PiecePlaceholder.OnRightPieceLeftPlaceholder -= HandleRightPieceLeftPlaceholderEvent;
    }
    public void HandlePieceFitEvent(bool isRightFit)
    {
        if (isRightFit)
        {
            rightPiecesCounter++;
            StartCoroutine(AudioManager.instance.PlayAudio(rightSFX, 0f));
        }

        if(rightPiecesCounter == totalPieces)
        {
            doneBtn.SetActive(true);
            StartCoroutine(AudioManager.instance.PlayAudio(puzzleCompleteSFX, 0f));
        }
    }

    public void HandleRightPieceLeftPlaceholderEvent()
    {
        //rightPiecesCounter--;
    }
}
