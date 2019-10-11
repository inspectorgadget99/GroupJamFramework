using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private string playerName;
    private Color playerColor;

    public string PlayerName { get => playerName; set => playerName = value; }
    public Color PlayerColor { get => playerColor; set => playerColor = value; }
}
