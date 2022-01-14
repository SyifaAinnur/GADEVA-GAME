using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Transisi
{
    private static GameObject player;
    
    // Start is called before the first frame update
    public static void SetPlayer(GameObject playerr)
    {
        player = playerr;

    }
    public static GameObject GetPlayer()
    {
        return player;
    }
    
}
