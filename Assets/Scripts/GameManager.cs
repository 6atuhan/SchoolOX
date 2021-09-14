using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject _karakterPrefab;
    public GameObject _nickPrefab;
    public GameObject _dogruskorPrefab;
    public GameObject _yanlisskorPrefab;
    public GameObject karakter;
    public GameObject nick;
    public GameObject dogruskor;
    public GameObject yanlisskor;
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Photon baðlanýp ve oyun sahnemize geçilince oluþturulacak nesneler.
            float x = Random.Range(-8f, 9f);
            float z = Random.Range(-3f, 7f);
            karakter = PhotonNetwork.Instantiate(_karakterPrefab.name, new Vector3(x, 1, z), Quaternion.identity);
            nick = PhotonNetwork.Instantiate(_nickPrefab.name, new Vector3(x, 1, z), Quaternion.identity);
            dogruskor = PhotonNetwork.Instantiate(_dogruskorPrefab.name, new Vector3(-10f, 8, 11), Quaternion.identity);
            yanlisskor = PhotonNetwork.Instantiate(_yanlisskorPrefab.name, new Vector3(18, 8, 11), Quaternion.identity);

            yanlisskor.SetActive(true);
            dogruskor.SetActive(true);
            nick.SetActive(true);
            
        }
    }

}

