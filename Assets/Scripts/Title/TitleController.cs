using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace kinjo{
    
    public class TitleController : MonoBehaviour
    {

        private string dataPath;
        private DataRW rw = new DataRW();
        private LoadData loadData = new LoadData();

    	//スコア表示するText型の変数
    	// public Text BlueberryScore;
 	    // public Text MuscatScore;
     	// public Text AppleScore;
        // public Text OrangeScore;
        //public string[] highScoreText = new string[4];
        public Text[] highScoreText = new Text[4];
        AudioSource pushIcon;

        //private string apple= "";

        private void Awake()
        {
            //初めに保存先を計算する　Application.dataPathで今開いているUnityプロジェクトのAssetsフォルダ直下を指定して、後ろに保存名を書く
            dataPath = Application.dataPath + "/Resources/json/data.json";
            //Debug.Log(dataPath);
        }

        void Start()
        {
            loadData = rw.LoadSceneData(dataPath);
            //Debug.Log(loadData.seasonsData[0].id);    // 1

            pushIcon = GetComponent<AudioSource>();

            for(int i = 0; i < loadData.seasonsData.Length; i++){
                highScoreText[i].text = "high score : " + loadData.seasonsData[i].highScore + "pt";
            }

        }
        // Start is called before the first frame update
        public void OnStartButtonClicked(string scene)
        {
            pushIcon.Play();
            SceneManager.LoadScene(scene);
        }
    }
}
