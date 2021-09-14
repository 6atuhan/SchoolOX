using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;
public class follownick : MonoBehaviourPunCallbacks
{
    public Transform hedef;
    public Vector3 fark;
    GameObject hedefcekme;
    
    void Start()
    {//takip edece�imiz nesneyi burda se�iyoruz.
        hedefcekme = GameObject.Find("GameManager").GetComponent<GameManager>().karakter;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {//kendi ekran�m�zda e�er kullan�c� biz isek bizim kullan�c� ad�m�z� yaz diyoruz.
            //Vektor3.lerp ile nickname yaz�y� nesneyi takip ettirmesini daha yum�ak bir hale getirdim.
           GetComponent<TextMesh>().text = PhotonNetwork.NickName;
            transform.position = Vector3.Lerp(transform.position, hedefcekme.transform.position - fark, 0.1f);
        }
           
    }
}
