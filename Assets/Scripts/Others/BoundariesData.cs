using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesData
{
    static bool[] isSpawnOnce;

    public static void InitBoundariesData(int boundaryAmount){
        isSpawnOnce = new bool[boundaryAmount];
    }
}
