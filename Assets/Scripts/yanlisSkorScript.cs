using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class yanlisSkorScript : MonoBehaviourPunCallbacks
{
    hareket _hareket;
    void Start()
    {
        _hareket = GameObject.FindGameObjectWithTag("Player").GetComponent<hareket>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            GetComponent<TextMesh>().text = "YANLIS : " + _hareket.yanlissayisi.ToString();
            transform.position = new Vector3(-13f, 8, 11);
        }
    }
}
