using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace kinjo{
    
    public class MenuController_yk : MonoBehaviour
    {

        private string _dataPath;
        private DataRW_yk rw = new DataRW_yk();
        private LoadData_yk loadData = new LoadData_yk();
        public Text[] highScoreText = new Text[4];
        public string JsonFileName;
        AudioSource IconButton;

    	//スコア表示するText型の変数
    	// public Text BlueberryScore;
 	    // public Text MuscatScore;
     	// public Text AppleScore;
        // public Text OrangeScore;
        //public string[] highScoreText = new string[4];


        //private string apple= "";

        private void Awake()
        {
            //初めに保存先を計算する　Application.dataPathで今開いているUnityプロジェクトのAssetsフォルダ直下を指定して、後ろに保存名を書く
            _dataPath = Application.dataPath + "/FruitFarm/Resources/json/" + JsonFileName; //seasonsData_yk.json";
            //Debug.Log(dataPath);
        }

        void Start()
        {
            loadData = rw.LoadSceneData(_dataPath);
            //Debug.Log(loadData.seasonsData[0].id);    // 1

            IconButton = GetComponent<AudioSource>();

            for(int i = 0; i < loadData.seasonsData.Length; i++){
                highScoreText[i].text = "high score : " + loadData.seasonsData[i].highScore + "pt";
            }

        }
        // Start is called before the first frame update
        public void OnStartButtonClicked(string scene)
        {
            IconButton.Play();
            SceneManager.LoadScene(scene);
        }
    }
}
