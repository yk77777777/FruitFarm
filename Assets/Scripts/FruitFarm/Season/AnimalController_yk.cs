using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kinjo {

    public class AnimalController_yk : MonoBehaviour
    {
        CharacterController controller;
        Animator animator;

        Vector3 moveDirection = Vector3.zero;

        public float gravity;
        public float speedZ;
        //public float speedX;
        public float speedJump;
        private float duration = 0;

        void Start() {
            //必要なコンポーネントを自動取得
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

//歩くときに縦軸をあげる
        void Update() {
            //moveDirection.y = moveDirection.y + 10 * Mathf.Sin(Time.time * 2f); // Mathf.PingPong(Time.time, 1.0f);
            if(controller.isGrounded){
                duration += Time.deltaTime;
                if(duration >= 1.0f){
                    moveDirection.y = 5.0f;
                    duration = 0;
                }
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

    //     const int MinLane = -2;
    //     const int MaxLane = 2;
    //     const float LaneWidth = 1.0f;
    //     const int DefaultLife = 3;
    //     const float StunDuration = 0.5f;

    //     CharacterController controller;
    //     Animator animator;

    //     Vector3 moveDirection = Vector3.zero;
    //     int targetLane;
    //     int life = DefaultLife;
    //     float recoverTime = 0.0f;

    //     public float gravity;
    //     public float speedZ;
    //     public float speedX;
    //     public float speedJump;
    //     public float accelerationZ;

    //     public int Life()
    //     {
    //         return life;
    //     }

    //     bool IsStun()
    //     {
    //         return recoverTime > 0.0f || life <= 0;
    //     }

    //     // Start is called before the first frame update
    //     void Start()
    //     {
    //         //必要なコンポーネントを自動取得
    //         controller = GetComponent<CharacterController>();
    //         animator = GetComponent<Animator>();
    //     }

    //     // Update is called once per frame
    //     void Update()
    //     {
    //         //デバッグ用
    //         if (Input.GetKeyDown("left")) MoveToLeft();
    //         if (Input.GetKeyDown("right")) MoveToRight();
    //         if (Input.GetKeyDown("space")) Jump();

    //         if (IsStun())
    //         {
    //             //動きを止め気絶状態からの復帰カウントを進める
    //             moveDirection.x = 0.0f;
    //             moveDirection.z = 0.0f;
    //             recoverTime -= Time.deltaTime;
    //         }
    //         else
    //         {
    //             //徐々に加速しZ方向に常に前進させる
    //             float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
    //             moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

    //             //X方向は目標のポジションまでの差分の割合で速度を計算
    //             float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
    //             moveDirection.x = ratioX * speedX;
    //         }


    //         //重力分の力を毎フレーム追加
    //         moveDirection.y -= gravity * Time.deltaTime;

    //         //移動実行
    //         Vector3 globalDirection = transform.TransformDirection(moveDirection);
    //         controller.Move(globalDirection * Time.deltaTime);

    //         //移動後接地したらY方向の速度はリセットする
    //         if (controller.isGrounded) moveDirection.y = 0;

    //         //速度が0以上なら走っているフラグをtrueにする
    //         animator.SetBool("run", moveDirection.z > 0.0f);
    //     }

    //     //左のレーンに移動を開始
    //     public void MoveToLeft()
    //     {
    //         if (IsStun()) return;
    //         if (controller.isGrounded && targetLane > MinLane) targetLane--;
    //     }

    //     //右のレーンに移動を開始
    //     public void MoveToRight()
    //     {
    //         if (IsStun()) return;
    //         if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    //     }

    //     public void Jump()
    //     {
    //         if (IsStun()) return;
    //         if (controller.isGrounded)
    //         {
    //             moveDirection.y = speedJump;

    //             //ジャンプトリガーを設定
    //             animator.SetTrigger("jump");
    //         }
    //     }
    //     // CharacterControllerに衝突判定が生じたときの処理
    //     void OnControllerColliderHit(ControllerColliderHit hit)
    //     {
    //         if (IsStun()) return;

    //         if (hit.gameObject.tag == "Robo")
    //         {
    //             //ライフを減らして気絶状態に移行
    //             life--;
    //             recoverTime = StunDuration;

    //             //ダメージトリガーを設定
    //             animator.SetTrigger("damage");

    //             //ヒットしたオブジェクトは削除
    //             Destroy(hit.gameObject);
    //         }
    //     }
    }

}