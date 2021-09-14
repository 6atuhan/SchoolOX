using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class dogruSkorScript : MonoBehaviourPunCallbacks
{
    hareket _hareket;
    void Start()
    {
        _hareket = GameObject.FindGameObjectWithTag("Player").GetComponent<hareket>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            GetComponent<TextMesh>().text ="DOGRU : "+ _hareket.dogrusayisi.ToString() ;
            transform.position = new Vector3(8, 8, 11);
        }
    }
}
