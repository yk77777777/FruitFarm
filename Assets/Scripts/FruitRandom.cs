using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitRandom : MonoBehaviour
    {
        public GameObject prefab;
        private float speed;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(RandomFruit());
        }

        // Update is called once per frame
        IEnumerator RandomFruit(){
            while(true){
                speed = Random.Range (1, 30);
                GameObject fruit = Instantiate(
                    prefab,
                    new Vector3(Random.Range(-12.0f,12.0f),Random.Range(8.0f,12.0f),Random.Range(-3.0f,3.0f)),
                    Quaternion.identity
                );
                fruit.GetComponent<Rigidbody>().velocity = transform.forward * speed;
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        // public GameObject prefab;
        // public GameController gc;

        // void Start () {
        //     StartCoroutine (Create ());
        // }
        // //コルーチンで生成を行う
        // IEnumerator Create(){
        //     //生成間隔の初期値
        //     float delta = 1.5f;
        //     while (true) {
        //         GameObject obj=Instantiate (
        //             prefab,
        //             new Vector3(Random.Range(-12.0f,12.0f),Random.Range(8.0f,12.0f),Random.Range(-3.0f,3.0f)),
        //             Quaternion.identity
                
        //         );
        //         //GameMangerをセットする。
        //         obj.GetComponent<FruitController> ().SetGameController(gc);
        //         //生成間隔時間停止
        //         yield return new WaitForSeconds (delta);
        //         //徐々に生成間隔を早める
        //         if (delta > 0.5f) {
        //             delta -= 0.05f;
        //         }
        //     }
        // }
    }
}
