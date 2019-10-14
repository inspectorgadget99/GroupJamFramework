using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private TextMesh floatingText;

    private Color playerColor;

    private void Start()
    {
        UpdateNickname();
    }

    public void UpdateNickname()
    {
        floatingText.text = PhotonNetwork.NickName;
    }

    public string GetName()
    {
        return PhotonNetwork.NickName;
    }
}
