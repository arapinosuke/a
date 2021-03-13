using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ゲーム管理クラス
public class GameManager : MonoBehaviour
{
    public const int MachingCount = 3;

    private enum GameState
    {
        Idle,
        PieceMove,
        MatchCheck,
        DeletePiece,
        FillPiece,
    }

    // serialize field.
    [SerializeField]
    private BallController board;

    // private.
    private GameState currentState;
    private BallGenerator selectedPiece;

=======
    private BallController ballController;
   

    // private.
    private GameState currentState;
    private BallGenerator selectedPiece;

>>>>>>> 54c928508d9cc4c4d4ad516847fa907d20de1883
    //-------------------------------------------------------
    // MonoBehaviour Function
    //-------------------------------------------------------
    // ゲームの初期化処理
    private void Start()
    {
        ballController.InitializeBoard(6, 5);

        currentState = GameState.Idle;
    }

    // ゲームのメインループ
    private void Update()
    {
        switch (currentState)
        {
            case GameState.Idle:
                Idle();
                break;
            case GameState.PieceMove:
                PieceMove();
                break;
            case GameState.MatchCheck:
                MatchCheck();
                break;
            case GameState.DeletePiece:
                DeletePiece();
                break;
            case GameState.FillPiece:
                FillPiece();
                break;
            default:
                break;
        }
    }

    //-------------------------------------------------------
    // Private Function
    //-------------------------------------------------------
    // プレイヤーの入力を検知し、ピースを選択状態にする
    private void Idle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedPiece = board.GetNearestPiece(Input.mousePosition);
            currentState = GameState.PieceMove;
        }
    }

    // プレイヤーがピースを選択しているときの処理、入力終了を検知したら盤面のチェックの状態に移行する
    private void PieceMove()
    {
        if (Input.GetMouseButton(0))
        {
            var piece = ballController.GetNearestPiece(Input.mousePosition);
            if (piece != selectedPiece)
            {
                ballController.SwitchPiece(selectedPiece, piece);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentState = GameState.MatchCheck;
        }
    }

    private void MatchCheck()
    {
        if (ballController.HasMatch())
        {
            currentState = GameState.DeletePiece;
        }
        else
        {
            currentState = GameState.Idle;
        }
    }

    private void Idle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            uiManager.ResetCombo();
            SelectPiece();
        }
    }

    private void PieceMove()
    {
        if (Input.GetMouseButton(0))
        {
            var piece = board.GetNearestPiece(Input.mousePosition);
            if (piece != selectedPiece)
            {
                board.SwitchPiece(selectedPiece, piece);
            }
            selectedPieceObject.transform.position = Input.mousePosition + Vector3.up * 10;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedPiece.SetPieceAlpha(1f);
            Destroy(selectedPieceObject);
            currentState = GameState.MatchCheck;
        }
    }

    private void MatchCheck()
    {
        if (board.HasMatch())
        {
            currentState = GameState.DeletePiece;
        }
        else
        {
            currentState = GameState.Idle;
        }
    }
    // マッチングしているピースを削除する
    private void DeletePiece()
    {
        ballController.DeleteMatchPiece();
        currentState = GameState.FillPiece;
    }

    // 盤面上のかけている部分にピースを補充する
    private void FillPiece()
    {
        ballController.FillPiece();
        currentState = GameState.MatchCheck;
    }
}