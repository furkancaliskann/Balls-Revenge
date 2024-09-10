using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject empty, singleWall, doubleWall, tripleWall, movingFan;


    public void OpenMap(Maps mapName)
    {
        switch (mapName)
        {
            case Maps.Empty: empty.SetActive(true); break;
            case Maps.SingleWall: singleWall.SetActive(true); break;
            case Maps.DoubleWall: doubleWall.SetActive(true); break;
            case Maps.TripleWall: tripleWall.SetActive(true); break;
            case Maps.MovingFan: movingFan.SetActive(true); break;
        }
    }
}

public enum Maps
{
    Empty,
    SingleWall,
    DoubleWall,
    TripleWall,
    MovingFan,
}

