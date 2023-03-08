using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

namespace kinjo {

    //定義したクラスをJSONデータに変換できるようにする
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        public string _dataPath;
        public float time;
        private string name;
        private int score = 0;
        public GUIStyle scoreStyle;
        public GUIStyle timeStyle;
        public GUIStyle msgStyle;

        private string msg = "";


        // //jsonファイルの読み込み処理
        // public string LoadData(string dataPath)
        // {
        //     //受け取ったパスのファイルを読み込む
        //     StreamReader reader = new StreamReader(dataPath);
        //     string datastr = reader.ReadToEnd();//ファイルの中身をすべて読み込む
        //     reader.Close();//ファイルを閉じる

        //     return JsonUtility.FromJson<string>(datastr);//読み込んだJSONファイルをPlayerData型に変換して返す
        // }

        // string datapath;

        // private void Awake()
        // {
        //     //初めに保存先を計算する
        //     datapath = Application.dataPath + "/FruitFarm.json";
        // }

        void Start()
        {
            //初期値を表示
		    //float型からint型へCastし、String型に変換して表示
		    //GetComponent<Text>().text = ((int)time).ToString();

            // PlayerData player2 = LoadTest(datapath);
            // Debug.Log("名前:" + player2.name + " HP:" + player2.hp + " Attack:" + player2.attack + " Defense:" + player2.defense);
        }


        // Update is called once per frame
        void Update()
        {
            if (msg == "GameOver") {
                //動きを止める
                Time.timeScale = 0f;
            }
        }

        void OnGUI(){
            GUI.Label (new Rect (5, 5, 10, 10), score.ToString(), scoreStyle);
            GUI.Label (new Rect (5, 5, 10, 10), time.ToString(), timeStyle);
            GUI.Label (new Rect (Screen.width/2-150, Screen.height/2-25, 300, 50), msg, msgStyle);
        }
        public int GetScore(){
            return score;
        }
        public void SetScore(int score){
            this.score = score;
        }
        public string GetMsg(){
            return msg;
        }
        public void SetMsg(string msg){
            this.msg = msg;
        }
    }
}
