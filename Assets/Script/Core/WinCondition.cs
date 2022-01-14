using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  WinCondition 
{
    static string Result;
    public static void SetResult(string result) =>  Result = result;

    public static string GetResult() =>  Result;
}
