using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace kinjo{

    public class DataRW_yk //: MonoBehaviour
    {        public LoadData_yk LoadSceneData(string dataPath)
        {
            StreamReader reader = new StreamReader(dataPath); //受け取ったパスのファイルを読み込む
            string datastr = reader.ReadToEnd();//ファイルの中身をすべて読み込む
            reader.Close();//ファイルを閉じる

            // 読み取った文字列をオブジェクト型に変換
            LoadData_yk inputJson = JsonUtility.FromJson<LoadData_yk>(datastr);

            // 配列名seasonsDataとJsonに記載された配列名が一致していないとヌルポとなるので、配列名が同一か確認すること。
            // Debug.Log(inputJson.seasonsData[0].id);    // 1
            // Debug.Break();
            return inputJson;
        }

        public void SaveSceneData(LoadData_yk loadData, string dataPath)
        {
            string jsonstr = JsonUtility.ToJson(loadData);//受け取ったloadDataをJSONに変換
            StreamWriter writer = new StreamWriter(dataPath, false);//初めに指定したデータの保存先を開く
            writer.WriteLine(jsonstr);//JSONデータを書き込み
            writer.Flush();//バッファをクリアする
            writer.Close();//ファイルをクローズする
        }
    }
}
