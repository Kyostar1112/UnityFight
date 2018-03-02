using UnityEngine;

public struct en_controller
{
    public float h;             //コントローラーｽﾃｨｯｸの値.
    public float v;             //コントローラーｽﾃｨｯｸの値.
    public float h_D;           //コントローラーｽﾃｨｯｸの値（-1か0か1）.
    public float v_D;           //コントローラーｽﾃｨｯｸの値（-1か0か1）.
    public bool Kick_w;        //キックﾎﾞﾀﾝが押されたかどうか.
}

public class _Playercontroller : MonoBehaviour
{
    public en_controller G_rcontroller;
    public en_controller B_rcontroller;
    public EN_P_COLOR P_color;
    public float Testh_D;
    public float Testv_D;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        switch (P_color)
        {
            case EN_P_COLOR.GREEN:
                //ｷｰ入力.
                G_rcontroller.h = Input.GetAxis("XBehavior");
                G_rcontroller.v = Input.GetAxis("ZBehavior");
                G_rcontroller.h_D = Input.GetAxisRaw("XBehavior");
                G_rcontroller.v_D = Input.GetAxisRaw("ZBehavior");
                Testh_D = G_rcontroller.h_D;
                Testv_D = G_rcontroller.v_D;
                if (Input.GetButtonDown("kick_weak_1"))
                {
                    G_rcontroller.Kick_w = true;
                }
                else
                {
                    G_rcontroller.Kick_w = false;
                }
                break;

            case EN_P_COLOR.BLUE:
                //ｷｰ入力.
                B_rcontroller.h = Input.GetAxis("XBehavior_2");
                B_rcontroller.v = Input.GetAxis("ZBehavior_2");
                B_rcontroller.h_D = Input.GetAxisRaw("XBehavior_2");
                B_rcontroller.v_D = Input.GetAxisRaw("ZBehavior_2");
                Testh_D = B_rcontroller.h_D;
                Testv_D = B_rcontroller.v_D;
                if (Input.GetButtonDown("kick_weak_2"))
                {
                    B_rcontroller.Kick_w = true;
                }
                else
                {
                    B_rcontroller.Kick_w = false;
                }
                break;
        }
    }
}