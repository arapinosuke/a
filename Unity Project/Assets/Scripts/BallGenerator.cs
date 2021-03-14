using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    //PieceがGenerator
    public GameObject Ball;
    public GameObject CharacterParent;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(Ball, CharacterParent.transform);
        }
    }

    public void SetKind(BallType ballType)
    {
        kind = ballController;
        BallType();
    }
    public BallController GetKind()
    {
        return kind;
    }

    private BallController ballController;
    public bool deleteFlag;
    private void SetColor()
    {
        switch (kind)
        {
            case BallController.Water:
                break;
            case PieceKind.Blue:
                thisImage.color = Color.blue;
                break;
            case PieceKind.Green:
                thisImage.color = Color.green;
                break;
            case PieceKind.Yellow:
                thisImage.color = Color.yellow;
                break;
            case PieceKind.Black:
                thisImage.color = Color.black;
                break;
            case PieceKind.Magenta:
                thisImage.color = Color.magenta;
                break;
            default:
                break;
        }
    }
}
