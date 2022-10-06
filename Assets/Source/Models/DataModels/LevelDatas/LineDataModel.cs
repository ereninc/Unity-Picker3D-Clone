﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LineDataModel
{
    public int Id;
    public RoadItemType Type;
    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public Vector3 ControlPointA;
    public Vector3 ControlPointB;


    public int MaxItemCount;
    public int IncPerLevelCount;
    public int StartItemCount;
    public int MaxLineValue;
    public int IncPerLevelValue;
    public int StartLineValue;

    public int GetItemCount(int playerCompletedCount)
    {
        int count = StartItemCount + (playerCompletedCount * IncPerLevelCount);
        count = count > MaxItemCount ? MaxItemCount : count;
        return count;
    }

    public int GetLineValue(int playerCompletedCount)
    {
        int maxValue = StartLineValue + (playerCompletedCount * IncPerLevelValue);
        maxValue = maxValue > MaxLineValue ? MaxLineValue : maxValue;
        return maxValue;
    }

    public Vector3 GetSpawnPosition(int maxItemCount, int index)
    {
        return Helpers.Maths.CalculateCubicBezierPoint((float)(index + 1) / (float)maxItemCount, StartPoint, ControlPointA, ControlPointB, EndPoint);
    }
}