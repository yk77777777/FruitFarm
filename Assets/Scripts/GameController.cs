using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace kinjo {

    //定義したクラスをJSONデータに変換できるようにする
    [System.Serializable]
    public class LoadData
    {
        public SeasonsData[] seasonsData;
    }

    public class GameController : MonoBehaviour
    {
        private string dataPath;
        private DataRW rw = new DataRW();
        public int sceneId;
        private LoadData loadData;
        private SeasonsData sceneData = new SeasonsData();
        private int idx;

        private int score = 0;
        //カウントダウン
    	public float countdown;
    	//時間を表示するText型の変数
    	public Text TimeText;
        public Text ScoreText;
        public Text MsgText;
        public Text HSMsgText;

        private string msg = "";
        private string hsMsg = "";
        //MenuButton;
        [SerializeField] private AudioSource as1;//AudioSource型の変数a1を宣言 使用するAudioSourceコンポーネントをアタッチ必要
        //TimeUp
        [SerializeField] private AudioSource as2;//AudioSource型の変数a2を宣言 使用するAudioSourceコンポーネントをアタッチ必要
        [SerializeField] private AudioClip ac1;//AudioClip型の変数b1を宣言 使用するAudioClipをアタッチ必要
        [SerializeField] private AudioClip ac2;//AudioClip型の変数b2を宣言 使用するAudioClipをアタッチ必要 

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

            as1 = GetComponent<AudioSource>();
            // as2 = GetComponent<AudioSource>();

            //scene判定
            for(int i = 0; i < loadData.seasonsData.Length; i++){
                if(loadData.seasonsData[i].id == sceneId)
                {
                    sceneData = loadData.seasonsData[i];
                    idx = i;
                    break;
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            //時間をカウントダウンする
            countdown -= Time.deltaTime;

            //時間を表示する
            TimeText.text = countdown.ToString("f0") + " s";

            //スコアを表示する
            ScoreText.text = "score : " + GetScore() + "pt";

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                //これ以降のUpdateはやめる
                enabled = false;
                SetMsg("TimeUp");
                MsgText.text = GetMsg();
                as2.Play();

                //ハイスコアを更新
                if(GetScore() > sceneData.highScore)
                {
                    SetHSMsg("High Score!");
                    HSMsgText.text = GetHSMsg();
                    loadData.seasonsData[idx].highScore = GetScore();
                    rw.SaveSceneData(loadData, dataPath);
                }
                //2秒後にReturnToTitleを呼び出す
                Invoke("ReturnToTitle", 2.0f);
            }
        }

        public void OnMenuButtonClicked()
        {
            as1.PlayOneShot(ac1);
            ReturnToTitle();
        }

        public void SetScore(int score){
            this.score = score;
        }
        public int GetScore(){
            return score;
        }
        public void SetMsg(string msg){
            this.msg = msg;
        }
        public string GetMsg(){
            return msg;
        }
        public void SetHSMsg(string hsMsg){
            this.hsMsg = hsMsg;
        }
        public string GetHSMsg(){
            return hsMsg;
        }

        void ReturnToTitle()
        {
            SceneManager.LoadScene("Title");
        }
    }
}
