using System;
using UnityEngine;

public class MutationHandler : MonoBehaviour 
{
    // Declare variables.
    public Sprite[] Crossed;
    public Sprite[] Selected;
    public Sprite[] DeSelected;
    public static int ElephantCounter, FishCounter, HawkCounter, RhinoCounter, TurtleCounter;
    public static int ElephantIndex, FishIndex, HawkIndex, RhinoIndex, TurtleIndex;
    
    /// <summary>
    /// Set mutation sprite.
    /// </summary>
    [Flags]
    public enum MutationType
    {
        Elephant = 1 << 0,
        Fish = 1 << 1,
        Hawk = 1 << 2,
        Rhino = 1 << 3,
        Turtle = 1 << 4
    }

    // Auto-properties.
    public static MutationType[] ThreeMutations { get; set; }
    public bool IsNormal { get; set; }
    public bool IsElephant { get; set; }
    public bool IsFish { get; set; }
    public bool IsHawk { get; set; }
    public bool IsRhino { get; set; }
    public bool IsTurtle { get; set; }
}