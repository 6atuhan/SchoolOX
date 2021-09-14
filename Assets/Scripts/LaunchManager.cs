using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    [Header("InputFields")]
    public InputField _oyuncuSayisiInputField;
    public InputField _nameInputField;
    [Header("LoginPanel")]
    public GameObject _LoginPanel;
    public Text status;

    [Header("GameSettingsPanel")]
    public GameObject _GameSettingsPanel;
    public Text oyuncuText;

    [Header("CreateJoinRoomPanel")]
    public GameObject _CreateJoinRoomPanel;
    
    [Header("RandomJoinRoomPanel")]
    public GameObject _RandomJoinRoomPanel;
    public Text randomroomtext;
    void Start()
    {
        ActiveLoginPanel();
        //burada herkesin ayný anda giriþini saðladýk.
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    
    #region PhotonCallBacks

    public override void OnConnectedToMaster()
    {// photon sunucusuna baðlandý metodu.
        status.text = "photona baðlandý";
        oyuncuText.text = PhotonNetwork.NickName+ " hoþgeldin.";
        //photon baðlanýnca diðer panele geçiyoruz.
        ActiveGameSettingsPanel();
    }
    public override void OnConnected()
    {//internete baðlandý metodu
        status.text = "internete baðlandý";
    }
    
    public override void OnJoinedRoom()
    {//odaya girince metodu
        PhotonNetwork.LoadLevel("OyunSahne");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //Eðer hýzlý giriþ týklanýnca oda yoksa, rastgele bir oda oluþturuyor.
        CreateRandomRoom();
    }


    #endregion
    #region UnityMethods

    public void onGiris()
    {
        status.text = "giriþ bilgileri alýndý";
        //nickname ile kullanýcý adý alýyoruz. boþ ise standart bi nick belirliyoruz.
        if (_nameInputField.text=="")
        { _nameInputField.text = "farecik ben"; }

        PhotonNetwork.NickName = _nameInputField.text;
        PhotonNetwork.ConnectUsingSettings(); 
    }

    public void ActiveLoginPanel()
    {
        _LoginPanel.SetActive(true);
    }
    public void ActiveCreateJoinRoomPanel()
    {
        _GameSettingsPanel.SetActive(false);
        _CreateJoinRoomPanel.SetActive(true);
    }
    public void ActiveGameSettingsPanel()
    {
        _LoginPanel.SetActive(false);
        _GameSettingsPanel.SetActive(true);
    }
    public void ActiveJoinRandomRoomPanel()
    {
        _GameSettingsPanel.SetActive(false);
        _RandomJoinRoomPanel.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        randomroomtext.text = "oda araniyor";
    }

    public void odaOlusturBes()
    {
        string odaismi = "ROOM5-" + Random.RandomRange(10, 100);
        string kisiSayisi = "5";
        RoomOptions _odaAyarlari = new RoomOptions();
        _odaAyarlari.IsOpen = true;
        _odaAyarlari.IsVisible = true;
        _odaAyarlari.MaxPlayers = (byte)int.Parse(kisiSayisi);
        PhotonNetwork.CreateRoom(odaismi, _odaAyarlari);
    }
    public void odaOlusturOn()
    {
        string odaismi = "ROOM10-" + Random.RandomRange(10, 100);
        string kisiSayisi = "10";
        RoomOptions _odaAyarlari = new RoomOptions();
        _odaAyarlari.IsOpen = true;
        _odaAyarlari.IsVisible = true;
        _odaAyarlari.MaxPlayers = (byte)int.Parse(kisiSayisi);
        PhotonNetwork.CreateRoom(odaismi, _odaAyarlari);

    }
    public void odaOlusturOnBes()
    {
        string odaismi = "ROOM15-" + Random.RandomRange(10, 100);
        string kisiSayisi = "15";
        RoomOptions _odaAyarlari = new RoomOptions();
        _odaAyarlari.IsOpen = true;
        _odaAyarlari.IsVisible = true;
        _odaAyarlari.MaxPlayers = (byte)int.Parse(kisiSayisi);
        PhotonNetwork.CreateRoom(odaismi, _odaAyarlari);
    }
    public void odaOlusturYirmi()
    {
        string odaismi = "ROOM20-" + Random.RandomRange(10, 100);
        string kisiSayisi = "20";
        RoomOptions _odaAyarlari = new RoomOptions();
        _odaAyarlari.IsOpen = true;
        _odaAyarlari.IsVisible = true;
        _odaAyarlari.MaxPlayers = (byte)int.Parse(kisiSayisi);
        PhotonNetwork.CreateRoom(odaismi, _odaAyarlari);
    }
    public void CreateRandomRoom()
    {
        string odaismi = "ROOM " + Random.RandomRange(10, 100);
        RoomOptions randomayar = new RoomOptions();
        randomayar.MaxPlayers = 20;
        randomayar.IsOpen = true;
        randomayar.IsVisible = true;
        PhotonNetwork.CreateRoom(odaismi, randomayar);
    }
    #endregion
}
