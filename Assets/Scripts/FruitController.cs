using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitController : MonoBehaviour
    {
        private GameController gc;

        void OnCollisionEnter(Collision coll){
            if (coll.gameObject.tag == "Animal") {
                gc.SetScore (gc.GetScore () + 1);
                Destroy (gameObject, 0.1f);
            }
            if (coll.gameObject.tag == "Ground") {
                gc.SetMsg("GameOver");
            }
        }
        public void SetGameController(GameController gc){
            this.gc = gc;
        }
    }
}
