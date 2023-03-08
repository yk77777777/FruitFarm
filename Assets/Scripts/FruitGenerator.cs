using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitGenerator : MonoBehaviour
    {
        public GameController gc;
        public GameObject Fruitprefab;
        private float speed;
        private float shotForce;
        private float shotTorque;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(RandomFruit());
        }

        // Update is called once per frame
        IEnumerator RandomFruit(){
            while(true){
                speed = Random.Range (0.1f, 30f);
                shotForce = Random.Range (100f, 500f);
                shotTorque = Random.Range (0f, 360f);
                GameObject fruit = Instantiate(
                    Fruitprefab,
                    transform.position +
                    new Vector3(Random.Range(-12.0f,12.0f),Random.Range(5.0f,20.0f),Random.Range(-12.0f,12.0f)),
                    Quaternion.identity
                );
                //fruit.GetComponent<Rigidbody>().velocity = transform.forward * speed;
                // Debug.Break();
                Rigidbody fruitRigidbody = fruit.GetComponent<Rigidbody>();
                fruitRigidbody.AddForce(transform.forward * shotForce);
                fruitRigidbody.AddTorque(new Vector3(0, shotTorque, 0));
                yield return new WaitForSeconds(0.05f);

                //GameControllerをセットする
                fruit.GetComponent<FruitController>().SetGameController(gc);
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
