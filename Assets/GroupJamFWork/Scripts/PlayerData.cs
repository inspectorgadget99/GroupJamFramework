using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private TextMesh floatingText;

    private PhotonView photonView;
    private Color playerColor;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }



    private void Start()
    {
        UpdateNickname();
    }

    public void UpdateNickname()
    {
        floatingText.text = photonView.Owner.NickName;
    }

    public string GetName()
    {
        return photonView.Owner.NickName;
    }
}
