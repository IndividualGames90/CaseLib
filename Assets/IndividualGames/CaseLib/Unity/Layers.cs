using UnityEngine;

public static class Layers
{
    public static readonly int Player = LayerMask.NameToLayer("Player");
    public static readonly int Ground = LayerMask.NameToLayer("Ground");
    public static readonly int Virus = 6;// LayerMask.GetMask("Virus");//DO NOT CHANGE THIS PUSHING BREAKS!
    public static readonly int UncapturedVirus = 7;//LayerMask.GetMask("UncapturedVirus");
}
