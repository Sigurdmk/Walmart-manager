using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LockCameraRadioScript : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    void Update()
    {
        int xPos = 30, yPos = 1000;
        SetCursorPos(xPos,yPos);//Call this to set the mouse position
    }
}
