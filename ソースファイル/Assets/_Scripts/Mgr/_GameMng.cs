using UnityEngine;
using UnityEngine.SceneManagement;

public enum game_Smode
{
    TITLE,
    MOVE,
    MAIN,
    CLEAR
}

public enum sentaku
{
    up,
    midle,
    down,
}

public enum EN_P_COLOR
{
    GREEN,
    BLUE,
};

public class _GameMng : MonoBehaviour
{
    public game_Smode gameSmode;
    public GameObject MainCam;
    public GameObject SubCam;

    //public int  PlayerMax=2;    //プレイヤー数は配列と合わせて.
    public GameObject g_Player;

    public GameObject b_Player;
    public GameObject canvas;
    public bool win;
    public sentaku KASOR;

    public bool Buttun;
    public float upDown;

    // Use this for initialization
    private void Start()
    {
        gameSmode = game_Smode.TITLE;
        //for( int i=0; i<PlayerMax; i++)
        //{
        //    Player.AddRange();
        //}
        KASOR = sentaku.up;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
        CameraPos(gameSmode);
        GameScene(gameSmode);
    }

    private void GameScene(game_Smode gameSmode)
    {
        switch (gameSmode)
        {
            case game_Smode.TITLE:
                title();
                Init();
                break;

            case game_Smode.MOVE:
                Move();
                break;

            case game_Smode.MAIN:
                Over();
                break;

            case game_Smode.CLEAR:
                Clear();
                break;
        }
    }

    private void Init()
    {

#if false
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].GetComponent<_PlayerMove>().P_mode = EN_P_E_MODE.Idle;
            Player[i].GetComponent<_PlayerMove>().Movement = new Vector3(0.0f, 0.0f, 0.0f);
            Player[i].GetComponent<_PlayerDrop>().Drop = true;
            Player[i].GetComponent<_PlayerDrop>().D_cnt = 200.0f;
            //Player[0].transform.position = new Vector3(-1.4f, 0.0f, -0.6f);
            //Player[1].transform.position = new Vector3(2.1f, 0.0f, -0.4f);
            //Player[i].transform.rotation = Quaternion.Euler(0.0f, -270.0f, 0.0f);
            //Player[i].transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        }
#endif

#if true
        g_Player.GetComponent<_PlayerMove>().P_mode = EN_P_E_MODE.Idle;
        b_Player.GetComponent<_PlayerMove>().P_mode = EN_P_E_MODE.Idle;
        b_Player.GetComponent<_PlayerMove>().Movement = new Vector3(0.0f, 0.0f, 0.0f);
        g_Player.GetComponent<_PlayerMove>().Movement = new Vector3(0.0f, 0.0f, 0.0f);
        b_Player.transform.rotation = Quaternion.Euler(0.0f, -270.0f, 0.0f);
        g_Player.transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
        b_Player.GetComponent<PlayerStartPos>().StartPos();
        g_Player.GetComponent<PlayerStartPos>().StartPos();
        g_Player.GetComponent<_PlayerDrop>().Drop = true;
        b_Player.GetComponent<_PlayerDrop>().Drop = true;
        g_Player.GetComponent<_PlayerDrop>().D_cnt = 200.0f;
        b_Player.GetComponent<_PlayerDrop>().D_cnt = 200.0f;
#endif
    }

    private void CameraPos(game_Smode gameSmode)
    {
        //ｶﾒﾗﾎﾟｼﾞｼｮﾝ.
        switch (gameSmode)
        {
            case game_Smode.TITLE:
                MainCam.SetActive(true);
                SubCam.SetActive(false);
                break;

            case game_Smode.MOVE:
                MainCam.SetActive(true);
                SubCam.SetActive(false);
                break;

            case game_Smode.MAIN:
                MainCam.SetActive(true);
                SubCam.SetActive(false);
                break;

            case game_Smode.CLEAR:
                MainCam.SetActive(false);
                SubCam.SetActive(true);
                break;
        }
    }

    private void title()
    {
        upDown = g_Player.GetComponent<_Playercontroller>().G_rcontroller.v_D;
        if (upDown >= 1)
        {
            KASOR = sentaku.up;
        }
#if false
        else if (upDown == 0.0f)
        {
            KASOR = sentaku.midle;
        }

#endif
        else if (upDown <= -1)
        {
            KASOR = sentaku.down;
        }
        Buttun = Input.GetButtonDown("Enter");
        if (Buttun)
        {
            switch (KASOR)
            {
                case sentaku.up:
                    gameSmode = game_Smode.MOVE;
                    break;
#if false
                case sentaku.midle:
                    SceneManager.LoadScene("Credit");
                    break;

#endif
                case sentaku.down:
                    Application.Quit();
                    break;
            }
        }
    }

    private void Move()
    {
        int fightcnt;
        fightcnt = canvas.GetComponent<UIMgr>().FIGHTCNT;
        if (fightcnt > 290)
        {
            gameSmode = game_Smode.MAIN;
        }
    }

    private void Over()
    {
        if (g_Player.GetComponent<_PlayerDrop>().D_cnt < 10.0f)
        {
            win = true;
            gameSmode = game_Smode.CLEAR;
        }
        if (b_Player.GetComponent<_PlayerDrop>().D_cnt < 10.0f)
        {
            win = false;
            gameSmode = game_Smode.CLEAR;
        }
    }

    private void Clear()
    {
        if (win)
        {
            b_Player.transform.position = new Vector3(-0.05935378f, 0.0f, -1.464567f);
            b_Player.transform.rotation = Quaternion.Euler(0.0f, -179.0f, 0.0f);
        }
        else
        {
            g_Player.transform.position = new Vector3(-0.05935378f, 0.0f, -1.464567f);
            g_Player.transform.rotation = Quaternion.Euler(0.0f, -179.0f, 0.0f);
        }

        if (Input.GetButtonDown("Enter"))
        {
            SceneManager.LoadScene("main");
#if false
            gameSmode = game_Smode.TITLE;
            b_Player.GetComponent<_PlayerDrop>().D_cnt = 200.0f;
            g_Player.GetComponent<_PlayerDrop>().D_cnt = 200.0f;
#endif
        }
    }
}