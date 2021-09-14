using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class soruMakinasi : MonoBehaviourPunCallbacks
{
    [Header("Sorular")] //Dizi olu�turunca materyal de�i�tirmiyor bu y�zden tek tek ald�m
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
    [Header("Di�er Materyaller")]
    public Material baslat1;
    public Material baslat2;
    public Material son;
    public int sorus�resi = 10;
    GameObject sorutahtas�;
    hareket hareketkodu;
    void Start()
    {
        //soru tahtas� olarak se�ti�im nesneyi buluyoruz. ismine g�re ar�yoruz.
        sorutahtas� = GameObject.Find("soru");
    }

    void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.IsMasterClient)//Oday� lu�turan yani masterclient ise P tu�una basarak sorular� ba�lat�yoruz.
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    photonView.RPC("materyalDegis", RpcTarget.All, 12);
                    photonView.RPC("sayacbaslat", RpcTarget.All);//Saya� ba�lat�yoruz

                }
            }
            if (zaman == 1)//sorular ba�l�yor materyali geliyor. RpcTarget.All herkeste g�r�nmesini sa�l�yor.
            {photonView.RPC("materyalDegis", RpcTarget.All,12);}
            if (zaman == sorus�resi*1) // ilk soru ba�l�yor.
            {photonView.RPC("materyalDegis", RpcTarget.All, 1);}
            if (zaman == sorus�resi * 2)
            {photonView.RPC("materyalDegis", RpcTarget.All, 2);}
            if (zaman == sorus�resi * 3)
            {photonView.RPC("materyalDegis", RpcTarget.All, 3);}
            if (zaman == sorus�resi * 4)
            {photonView.RPC("materyalDegis", RpcTarget.All, 4);}
            if (zaman == sorus�resi * 5)
            {photonView.RPC("materyalDegis", RpcTarget.All, 5);}
            if (zaman == sorus�resi *6)
            {photonView.RPC("materyalDegis", RpcTarget.All, 6);}
            if (zaman == sorus�resi *7)
            {photonView.RPC("materyalDegis", RpcTarget.All, 7);}
            if (zaman == sorus�resi *8)
            {photonView.RPC("materyalDegis", RpcTarget.All, 8);}
            if (zaman == sorus�resi *9)
            {photonView.RPC("materyalDegis", RpcTarget.All, 9);}
            if (zaman == sorus�resi *10)
            {photonView.RPC("materyalDegis", RpcTarget.All, 10);}
            if (zaman == sorus�resi *11)
            {photonView.RPC("materyalDegis", RpcTarget.All, 13);}
            if (zaman == sorus�resi *12)
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
        //sorular�n materyali de�i�tirme i�lemi.
        if (sira == 1)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru1;
        if (sira == 2)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru2;
        if (sira == 3)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru3;
        if (sira == 4)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru4;
        if (sira == 5)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru5;
        if (sira == 6)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru6;
        if (sira == 7)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru7;
        if (sira == 8)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru8;
        if (sira == 9)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru9;
        if (sira == 10)
            sorutahtas�.GetComponent<MeshRenderer>().material = soru10;
        //giri� ve ��k�� materyali de�i�tirme
        if (sira == 11)//baslat materyali
            sorutahtas�.GetComponent<MeshRenderer>().material = baslat1;
        if (sira == 12)//basl�yor materyali
            sorutahtas�.GetComponent<MeshRenderer>().material = baslat2;
        if (sira == 13)//bitti materyali
            sorutahtas�.GetComponent<MeshRenderer>().material = son;


    }
    [PunRPC]
    void sayacbaslat()
    {
        InvokeRepeating("sayac", 0, 1);
    }
}
