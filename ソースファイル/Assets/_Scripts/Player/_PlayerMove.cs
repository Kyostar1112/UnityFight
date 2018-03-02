using System.Collections.Generic;
using UnityEngine;

public enum EN_P_E_MODE
{
    Idle,
    Attak,
    Run,
    Damage,
};

public class _PlayerMove : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Cambas;
    public GameObject GameMng;
    private Rigidbody playerRigid;	            //ﾌﾟﾚｲﾔｰのrigidbody用.
    private Animator animator;                  //動かすｱﾆﾒｰﾀ.
    private float Move_f = 3.0f;	            //移動量.
    public Vector3 Movement;			        //動いているﾍﾞｸﾄﾙ.
    public EN_P_E_MODE P_mode;
    private float Rotationalspeed = 0.5f;
    private Quaternion tar_rotation;            // キャラクターのy軸の角度.
    private Quaternion rotation;               //　前の角度
    private Vector3 ground;
    private en_controller Controll;
    public EN_P_COLOR P_color;
    private game_Smode gamemode;
    private float DamageTimeMax = 30.0f;
    public bool b_Damage;
    public float DamageTime;
    private float TimeCount;
    public float AttakCnt;
    public List<AudioClip> Se = new List<AudioClip>();
    private AudioSource audioSource;
    private bool AtkSoundFlg;
    public bool DamageFlg;
    private Transform[] tr_child;
    public List<Renderer> MeshRenderSet;
    public int WakeCnt;

    private void Start()
    {
        WakeCnt = 0;
        tr_child = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tr_child.Length; i++)
        {
            if (null != tr_child[i].GetComponent<Renderer>())
            {
                MeshRenderSet.Add(tr_child[i].GetComponent<Renderer>());
            }
        }
        audioSource = GetComponent<AudioSource>();
        AtkSoundFlg = false;
        AttakCnt = 0;
        TimeCount = 0;
        DamageTime = DamageTimeMax;
        b_Damage = false;
        animator = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody>();	//ﾌﾟﾚｲﾔｰのRigidbodyを探し出す.
        Movement = new Vector3(0.0f, 0.0f, 0.0f);
        rotation = Quaternion.identity;
        tar_rotation = Quaternion.identity;
        P_mode = EN_P_E_MODE.Idle;
        P_color = GetComponent<_Playercontroller>().P_color;
        DamageFlg = true;
    }

    // Update is called once per frame
    private void Update()
    {
        gamemode = GameMng.GetComponent<_GameMng>().gameSmode;
        switch (P_color)
        {
            case EN_P_COLOR.GREEN:
                Controll = GetComponent<_Playercontroller>().G_rcontroller;
                break;

            case EN_P_COLOR.BLUE:
                Controll = GetComponent<_Playercontroller>().B_rcontroller;
                break;
        }

        if (gamemode == game_Smode.TITLE)
        {
            playerRigid.velocity = Vector3.zero;
            // 回転しない設定.
            playerRigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            //playerRigid.constraints = RigidbodyConstraints.FreezeRotation;
        }

        AnimatorStateInfo anim = this.animator.GetCurrentAnimatorStateInfo(0);
        if (gamemode == game_Smode.MAIN)
        {
            if (GetComponent<_PlayerDrop>().Drop)
            {
                ground = transform.position;
                //ground.y = 0.0f;
                transform.position = ground;
                //if( Controll.h!=0 || Controll.v != 0)
                //{
                //    if ( !anim.IsTag("attak_w") ) {
                //        P_mode = EN_P_E_MODE.Idle;
                //    }
                //}

                //旧.
#if false
                if (P_mode == EN_P_E_MODE.Damage)
                {
                    TimeCount++;
                    if (DamageTime > 0.0f)
                    {
                        animator.SetBool("Wake", false);
                        b_Damage = true;
                        //if (TimeCount % 6 == 0)
                        //{
                        DamageTime--;
                        //}
                    }
                    else
                    {
                        transform.Translate((Vector3.back * 0.03f));
                        animator.SetBool("Wake", true);
                        b_Damage = false;
                        playerRigid.velocity = Vector3.zero;
                    }

                    if (TimeCount % 2 == 0)
                    {
                        for (int j = 0; j < MeshRenderSet.Count; j++)
                        {
                            MeshRenderSet[j].enabled = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < MeshRenderSet.Count; i++)
                        {
                            MeshRenderSet[i].enabled = true;
                        }
                    }
                }

                if (anim.IsTag("Idle") && b_Damage == false)
                {
                    AtkSoundFlg = false;
                    b_Damage = false;
                    if (!b_Damage)
                    {
                        for (int i = 0; i < MeshRenderSet.Count; i++)
                        {
                            MeshRenderSet[i].enabled = true;
                        }
                        DamageFlg = true;
                        AttakCnt = 0.0f;
                        DamageTime = DamageTimeMax;
                        P_mode = EN_P_E_MODE.Idle;
                        TimeCount = 0.0f;
                    }
                }

#endif
#if true
                if (P_mode == EN_P_E_MODE.Damage)
                {
                    
                    TimeCount++;
                    //if (DamageTime > 0.0f)
                    //{
                    //    animator.SetBool("Wake", false);
                    //    b_Damage = true;
                    //    //if (TimeCount % 6 == 0)
                    //    //{
                    //    DamageTime--;
                    //    //}
                    //}
                    //else
                    //{
                    //}

                    transform.Translate(0, 0, -1 * 0.03f);
                    animator.SetBool("Wake", true);
                    b_Damage = false;
                    if (anim.IsTag("HandSpring"))
                    {
                        WakeCnt++;
                    }
                    if (TimeCount % 2 == 0)
                    {
                        for (int j = 0; j < MeshRenderSet.Count; j++)
                        {
                            MeshRenderSet[j].enabled = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < MeshRenderSet.Count; i++)
                        {
                            MeshRenderSet[i].enabled = true;
                        }
                    }
                }

                //ダメージ処理の終了後の初期化.
                //if (WakeCnt > 36 && b_Damage == false)
                //{
                if (anim.IsTag("Idle") && b_Damage == false)
                {
                        AtkSoundFlg = false;
                    for (int i = 0; i < MeshRenderSet.Count; i++)
                    {
                        MeshRenderSet[i].enabled = true;
                    }
                    animator.SetBool("Down", false);
                    animator.SetBool("Wake", false);
                    DamageFlg = true;
                    AttakCnt    = 0.0f;
                    DamageTime  = DamageTimeMax;
                    P_mode      = EN_P_E_MODE.Idle;
                    TimeCount   = 0.0f;
                    WakeCnt     = 0;
                }
#endif



                if (Controll.Kick_w)
                {
                    if (P_mode == EN_P_E_MODE.Idle
                        || P_mode == EN_P_E_MODE.Run)
                    {
                        animator.SetTrigger("KickWeekFlg");
                    }
                }

                if (anim.IsTag("attak_w"))
                {
                    if (!AtkSoundFlg)
                    {
                        audioSource.clip = Se[0];
                        audioSource.Play();
                        AtkSoundFlg = true;
                    }
                    AttakCnt++;
                    if (13.0f < AttakCnt && AttakCnt < 15.0f)
                    {
                        P_mode = EN_P_E_MODE.Attak;
                    }
                }

                if (!anim.IsTag("attak_w"))
                {
                    if (Controll.h != 0 || Controll.v != 0)
                    {
                        if (P_mode == EN_P_E_MODE.Idle
                            || P_mode == EN_P_E_MODE.Run
                            || P_mode != EN_P_E_MODE.Damage)
                        {
                            if (!anim.IsTag("Wake") && !anim.IsTag("Down"))
                            {
                                if (anim.IsTag("Idle") || anim.IsTag("Run"))
                                {
                                    P_mode = EN_P_E_MODE.Run;
                                    Move(Controll.h, Controll.v);
                                }
                            }
                        }
                    }
                    C_Rotation();

                    KeyDistant();
                }
            }
        }
        else
        {
            if (!anim.IsTag("Idle"))
            {
                animator.SetTrigger("Init");
            }
            KeyDistant();
        }
        if (gamemode == game_Smode.CLEAR)
        {
            if (!anim.IsTag("Idle"))
            {
                animator.SetTrigger("Init");
            }
            animator.SetBool("RunFlg", false);
            P_mode = EN_P_E_MODE.Idle;
        }
    }

    public void KeyDistant()
    {
        if (Controll.h_D == 0 && Controll.v_D == 0)
        {
            animator.SetBool("RunFlg", false);
        }
    }

    //移動関数.
    private void Move(float h, float v)
    {
        if (Controll.h_D != 0 || Controll.v_D != 0)
        {
            animator.SetBool("RunFlg", true);

            //移動するﾍﾞｸﾄﾙを設定.
            Movement.Set(h, 0.0f, v);

            //移動するﾍﾞｸﾄﾙを正規する.
            Movement = Movement.normalized * Time.deltaTime * Move_f;

            //Rigidbodyを移動させる　→　現在の座標に移動するﾍﾞｸﾄﾙを足す.
            playerRigid.MovePosition(transform.position + Movement);
        }
    }

    //ﾓﾃﾞﾙ方向転換用関数.
    private void C_Rotation()
    {
        if (P_mode == EN_P_E_MODE.Run)
        {
            if (Movement.x > 0.0f)
            {
                tar_rotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                if (Movement.z > 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);
                }
                else if (Movement.z < 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 135.0f, 0.0f);
                }
            }
            else if (Movement.x < 0.0f)
            {
                tar_rotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
                if (Movement.z > 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 315.0f, 0.0f);
                }
                else if (Movement.z < 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 225.0f, 0.0f);
                }
            }
            else if (Movement.x == 0.0f)
            {
                if (Movement.z > 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                }
                else if (Movement.z < 0.0f)
                {
                    tar_rotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                }
            }

            rotation = Quaternion.Euler(0, rotation.eulerAngles.y + Rotationalspeed, 0);

            rotation = Quaternion.RotateTowards(rotation, tar_rotation, Time.deltaTime * 5.0f);
            rotation = tar_rotation;

            //if (Movement.x > 0.0f)
            //{ //　キーを押している度合い（xとy軸両方）が0.1より大きい時
            //    animator.SetFloat("speed", 1f); //　アニメーションパラメータのspeedの値にvelocity.magnitudeを入れる
            //}
            //else
            //{ //　キーを押している度合いが小さい時
            //    animator.SetFloat("speed", 0f); //　アニメーションパラメータのspeedに0を入れて立っているアニメーションにする
            //}

            transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        }
    }

    public void PlayerDamage(Transform heading, float ForcePo)
    {
        AnimatorStateInfo anim = this.animator.GetCurrentAnimatorStateInfo(0);
        if (!anim.IsTag("Down"))
        {
            if (!anim.IsTag("Wake"))
            {
                if (DamageFlg)
                {
                    animator.SetBool("Down",true);
                    P_mode = EN_P_E_MODE.Damage;
                    //方向設定.                       
                    transform.LookAt(heading);//攻撃したときUnityChangがこっちを向く.
                    audioSource.clip = GetComponent<_PlayerMove>().Se[1];
                    audioSource.Play();
                    //playerRigid.velocity = -ForcePo * transform.forward;
                    //playerRigid.AddForce(-transform.forward / ForcePo, ForceMode.Impulse);
                    DamageFlg = false;

                }
            }
        }
    }
}

//playermove = enPlayerMode.Damage;
//playermove = enPlayerMode.Dead;
//animator.SetBool("isDead", true);
//animator.SetTrigger("isDamaging");
//Vector3 pos = col.transform.forward;
//       Vector3 newVector = (pos).normalized;
//       rigidbody.velocity = newVector * 30;