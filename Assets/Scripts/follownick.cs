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
    {//takip edeceðimiz nesneyi burda seçiyoruz.
        hedefcekme = GameObject.Find("GameManager").GetComponent<GameManager>().karakter;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {//kendi ekranýmýzda eðer kullanýcý biz isek bizim kullanýcý adýmýzý yaz diyoruz.
            //Vektor3.lerp ile nickname yazýyý nesneyi takip ettirmesini daha yumþak bir hale getirdim.
           GetComponent<TextMesh>().text = PhotonNetwork.NickName;
            transform.position = Vector3.Lerp(transform.position, hedefcekme.transform.position - fark, 0.1f);
        }
           
    }
}
