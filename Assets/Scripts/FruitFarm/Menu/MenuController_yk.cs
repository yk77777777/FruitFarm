using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace kinjo{
    
    public class MenuController_yk : MonoBehaviour
    {

        // private string _dataPath;
        // private DataRW_yk rw = new DataRW_yk();
        // private LoadData_yk loadData = new LoadData_yk();
        // public Text[] highScoreText = new Text[4];
        // public string JsonFileName;
        AudioSource IconButton;

        //private string apple= "";

        void Start()
        {
            IconButton = GetComponent<AudioSource>();
        }
        // Start is called before the first frame update
        public void OnStartButtonClicked(string scene)
        {
            IconButton.Play();
            SceneManager.LoadScene(scene);
        }
    }
}
