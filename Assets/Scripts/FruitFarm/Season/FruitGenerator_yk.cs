using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitGenerator_yk : MonoBehaviour
    {
        public GameController_yk gc;

        public GameObject[] Fruitprefab = new GameObject[3];
        public int rangeNum1;
        public int rangeNum2;
        //public int num3;

        private int idx;
        private int rdmNo;
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
                rdmNo = Random.Range (1, 101);
                if(rdmNo <= rangeNum1){
                    idx = 2;
                }else if(rdmNo <= rangeNum2){
                    idx = 1;
                }else{
                    idx = 0;
                }
                GameObject fruit = Instantiate(
                    Fruitprefab[idx],
                    transform.position +
                    new Vector3(Random.Range(-12.0f,12.0f),Random.Range(5.0f,20.0f),Random.Range(-12.0f,12.0f)),
                    Quaternion.identity
                );
                //fruit.GetComponent<Rigidbody>().velocity = transform.forward * speed;
                //Debug.Break();

                //GameControllerをセットする
                fruit.GetComponent<FruitController_yk>().SetGameController(gc);

                Rigidbody fruitRigidbody = fruit.GetComponent<Rigidbody>();
                fruitRigidbody.AddForce(transform.forward * shotForce);
                fruitRigidbody.AddTorque(new Vector3(0, shotTorque, 0));



                yield return new WaitForSeconds(0.05f);


            }
        }
    }
}
