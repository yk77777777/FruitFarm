using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class FruitController_yk : MonoBehaviour
    {
        private GameController_yk gc;
        public int point;
        AudioSource pickSound;

        void Start()
        {
            pickSound = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision coll){
            if (coll.gameObject.tag == "Animal") {
                //サウンド再生
                pickSound.Play();
                //ポイント獲得
                if(gc.GetScore() + point < 0)
                {
                    gc.SetScore (0);
                }
                else
                {
                    gc.SetScore (gc.GetScore() + point);
                    Destroy (this.gameObject, 0.1f);
                }
            }
            Destroy(this.gameObject, 1.0f);
            // if (coll.gameObject.tag == "Ground") {
            //     gc.SetMsg("GameOver");
            // }
        }
        public void SetGameController(GameController_yk gc){
            this.gc = gc;
        }
    }
}
