using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public int startLives = 3;

    public static int killedObjects = 0;

    void Start()
    {
        Lives = startLives;
        killedObjects = 0;
    }

}
