using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using System;

public class hareket : MonoBehaviourPunCallbacks
{
    Animator anim;
    public int puan;
    soruMakinasi sorumakinasi;
    GameObject nick;
    public int dogrusayisi = 0;
    public int yanlissayisi = 0;

    void Start()
    {
        sorumakinasi = GameObject.Find("soru").GetComponent<soruMakinasi>();
        anim = GetComponent<Animator>();
        nick = GameObject.Find("GameManager").GetComponent<GameManager>().nick;
        nick.SetActive(true);
    }
    float vert, horz;
    float speed=6;

    void Update()
    {
        
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");
        //bizim karakterimize haraket saðlýyoruz.
        if (photonView.IsMine)
        {
        transform.position += new Vector3(horz, 0, vert).normalized * speed * Time.deltaTime;

        if ( vert>0||horz>0||horz<0 ||vert<0)
            { anim.SetTrigger("koþ"); }
        else { anim.SetTrigger("dur"); }
        
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.1f);}
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.1f);}
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);}
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.1f);}  
        }
        cevapkontrol();
    }
    public int cevap=2;
    //0 yanlýþ 1 doðru 2 boþ;
    private void OnTriggerEnter(Collider other)
    {// kýrmýzý yeþil ve zemine temas ettiðindeki cevaplarýn deðiþmesini saðlýyorum.
        if (photonView.IsMine)
        {
            if(other.gameObject.name=="doðru")
            { cevap = 1; }
            if(other.gameObject.name=="yanlýþ")
            { cevap = 0; }
            if(other.gameObject.name=="Plane")
            { cevap = 2; }
        }   
    }

    void cevapkontrol()
    {// cevap kontrolleri tek tek if ile yaptým. Süreyi çekip döngüye sokarak daha kýsa daha düzenli kod oluyordu ama bu sefer Photon kýsmýnda çakýþmalar oluyor.
        
        if (photonView.IsMine)
        {
            if (sorumakinasi.zaman == 20)
            {
                if (cevap == 1)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 0)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 30)
            {
                if (cevap == 0)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 1)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 40)
            {
                if (cevap == 0)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 1)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 50)
            {
                if (cevap == 1)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 0)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 60)
            {
                if (cevap == 0)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 1)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 70)
            {
                if (cevap == 0)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 1)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 80)
            {
                if (cevap == 1)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 0)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 90)
            {
                if (cevap == 0)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 1)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 100)
            {
                if (cevap == 1)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 0)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
            if (sorumakinasi.zaman == 110)
            {
                if (cevap == 1)
                {
                    dogrusayisi++;
                    cevap = 2;
                    randomyer();
                }
                else if (cevap == 0)
                {
                    yanlissayisi++;
                    cevap = 2;
                    randomyer();
                }
            }
        }
    }

    private void randomyer()
    {//her soru sonrasýnda ayný cevap alanýnda kalmasýn diye soru bitiminde herkesi ayný yer ýþýnlýyorum.
        if(photonView.IsMine)
        {
            transform.position = new Vector3(0, 1, 0);
        }
        
    }
}
