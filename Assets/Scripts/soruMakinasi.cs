using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class soruMakinasi : MonoBehaviourPunCallbacks
{
    [Header("Sorular")] //Dizi oluþturunca materyal deðiþtirmiyor bu yüzden tek tek aldým
    public Material soru1;
    public Material soru2;
    public Material soru3;
    public Material soru4;
    public Material soru5;
    public Material soru6;
    public Material soru7;
    public Material soru8;
    public Material soru9;
    public Material soru10;
    [Header("Diðer Materyaller")]
    public Material baslat1;
    public Material baslat2;
    public Material son;
    public int sorusüresi = 10;
    GameObject sorutahtasý;
    hareket hareketkodu;
    void Start()
    {
        //soru tahtasý olarak seçtiðim nesneyi buluyoruz. ismine göre arýyoruz.
        sorutahtasý = GameObject.Find("soru");
    }

    void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.IsMasterClient)//Odayý luþturan yani masterclient ise P tuþuna basarak sorularý baþlatýyoruz.
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    photonView.RPC("materyalDegis", RpcTarget.All, 12);
                    photonView.RPC("sayacbaslat", RpcTarget.All);//Sayaç baþlatýyoruz

                }
            }
            if (zaman == 1)//sorular baþlýyor materyali geliyor. RpcTarget.All herkeste görünmesini saðlýyor.
            {photonView.RPC("materyalDegis", RpcTarget.All,12);}
            if (zaman == sorusüresi*1) // ilk soru baþlýyor.
            {photonView.RPC("materyalDegis", RpcTarget.All, 1);}
            if (zaman == sorusüresi * 2)
            {photonView.RPC("materyalDegis", RpcTarget.All, 2);}
            if (zaman == sorusüresi * 3)
            {photonView.RPC("materyalDegis", RpcTarget.All, 3);}
            if (zaman == sorusüresi * 4)
            {photonView.RPC("materyalDegis", RpcTarget.All, 4);}
            if (zaman == sorusüresi * 5)
            {photonView.RPC("materyalDegis", RpcTarget.All, 5);}
            if (zaman == sorusüresi *6)
            {photonView.RPC("materyalDegis", RpcTarget.All, 6);}
            if (zaman == sorusüresi *7)
            {photonView.RPC("materyalDegis", RpcTarget.All, 7);}
            if (zaman == sorusüresi *8)
            {photonView.RPC("materyalDegis", RpcTarget.All, 8);}
            if (zaman == sorusüresi *9)
            {photonView.RPC("materyalDegis", RpcTarget.All, 9);}
            if (zaman == sorusüresi *10)
            {photonView.RPC("materyalDegis", RpcTarget.All, 10);}
            if (zaman == sorusüresi *11)
            {photonView.RPC("materyalDegis", RpcTarget.All, 13);}
            if (zaman == sorusüresi *12)
            {
                photonView.RPC("materyalDegis", RpcTarget.All, 11);
                CancelInvoke("sayac");
                zaman = 0;
            }
        }
    }
    public int zaman=0;
    void sayac()
    {
        zaman++;
    }

    [PunRPC]
    void materyalDegis(int sira)
    {
        //sorularýn materyali deðiþtirme iþlemi.
        if (sira == 1)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru1;
        if (sira == 2)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru2;
        if (sira == 3)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru3;
        if (sira == 4)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru4;
        if (sira == 5)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru5;
        if (sira == 6)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru6;
        if (sira == 7)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru7;
        if (sira == 8)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru8;
        if (sira == 9)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru9;
        if (sira == 10)
            sorutahtasý.GetComponent<MeshRenderer>().material = soru10;
        //giriþ ve çýkýþ materyali deðiþtirme
        if (sira == 11)//baslat materyali
            sorutahtasý.GetComponent<MeshRenderer>().material = baslat1;
        if (sira == 12)//baslýyor materyali
            sorutahtasý.GetComponent<MeshRenderer>().material = baslat2;
        if (sira == 13)//bitti materyali
            sorutahtasý.GetComponent<MeshRenderer>().material = son;


    }
    [PunRPC]
    void sayacbaslat()
    {
        InvokeRepeating("sayac", 0, 1);
    }
}
