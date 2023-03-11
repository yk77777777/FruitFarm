using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitController : MonoBehaviour
    {
        private GameController gc;
        public int point;

        void OnCollisionEnter(Collision coll){
            if (coll.gameObject.tag == "Animal") {
                gc.SetScore (gc.GetScore() + point);
                Destroy (this.gameObject, 0.1f);
            }
            Destroy(this.gameObject, 1.0f);
            // if (coll.gameObject.tag == "Ground") {
            //     gc.SetMsg("GameOver");
            // }
        }
        public void SetGameController(GameController gc){
            this.gc = gc;
        }
    }
}
