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

    private BallType kind;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(Ball, CharacterParent.transform);
        }
    }

    public void SetKind(BallType ballType)
    {
        kind = ballType;
        SetColor();
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
            case BallType.Water:
                break;
            case BallType.Wind:
                break;
            case BallType.Fire:
                break;
            case BallType.Dark:
                break;
            case BallType.Light:
                break;
            case BallType.Heal:
                break;
            default:
                break;
        }
    }
}
