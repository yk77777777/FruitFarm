using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class AnimalController_yk : MonoBehaviour
    {
    
        
        [SerializeField]
        AudioClip[] audioClips;
        AudioSource audioSource;
        CharacterController controller;
        Animator animator;
        GameController_yk gc;

        Vector3 moveDirection = Vector3.zero;

        public float gravity;
        public float speedX;
        public float speedZ;
        //public float speedX;
        public float speedJump;
        private float duration = 0;
        private int pointNum = 0;

        void Start() {
            //必要なコンポーネントを自動取得
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

//歩くときに縦軸をあげる
        void Update() {
            //moveDirection.y = moveDirection.y + 10 * Mathf.Sin(Time.time * 2f); // Mathf.PingPong(Time.time, 1.0f);
            if(controller.isGrounded){

                //つねに上下移動（呼吸ぽく）
                duration += Time.deltaTime;
                if(duration >= 1.0f){
                    moveDirection.y = 0.4f;
                    duration = 0;
                }

                moveDirection.z = transform.position.x * speedX;;

                if(Input.GetAxis("Vertical") > 0.0f){
                    moveDirection.z = Input.GetAxis("Vertical") * speedZ;
                    
                }else{
                    moveDirection.z = 0;
                }

                transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

                if(Input.GetButton("Jump")){
                    moveDirection.y = speedJump;
                    animator.SetTrigger("jump");
                }
            }

            //重力分の力のを毎フレーム追加
            moveDirection.y -= gravity * Time.deltaTime;

            //移動実行
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            controller.Move(globalDirection * Time.deltaTime);

            //移動後接地してたらY方向の速度はリセットする
            if(controller.isGrounded) moveDirection.y = 0;

            //速度が0以上なら走っているフラグをtrueにする
            animator.SetBool("run", moveDirection.z > 0.0f);
        }

        void OnCollisionEnter(Collision coll){
            switch (coll.gameObject.tag)
            {
                case "Fruit":
                    //pointNum = point[0];
                    audioSource.PlayOneShot(audioClips[0]);
                    break;
                case "FruitBlack":
                    //pointNum = point[1];
                    audioSource.PlayOneShot(audioClips[1]);
                    break;
                case "FluitGold":
                    //pointNum = point[2];
                    audioSource.PlayOneShot(audioClips[2]);
                    break;
            }
        }

        // public void SetGameController(GameController_yk gc){
        //     this.gc = gc;
        // }
    }

}