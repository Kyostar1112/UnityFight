using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public GameObject Canbas;
    public GameObject Fight;
    public GameObject r_arrow;
    public GameObject ClearCanbas;
    public GameObject G_win;
    public GameObject B_win;
    public GameObject PlayerMng;
    private float ytyousei_S;
    public float ytyousei_C;
    private float ytyousei_E;
    public Vector3 C_kari;
    private game_Smode gameSmode_l;
    public sentaku Kasor;
    public float upDown;
    public int FIGHTCNT;
    private float Kaxolx = 443.65f;

    // Use this for initialization
    private void Start()
    {
        ytyousei_S = 393.2f;
        ytyousei_C = 314.0f;
        ytyousei_E = 243.5f;
        C_kari = r_arrow.transform.position;
        r_arrow.transform.position = C_kari;
    }

    // Update is called once per frame
    private void Update()
    {
        Kasor = PlayerMng.GetComponent<_GameMng>().KASOR;
        gameSmode_l = PlayerMng.GetComponent<_GameMng>().gameSmode;
        switch (gameSmode_l)
        {
            case game_Smode.TITLE:
                Init();
                title();
                break;

            case game_Smode.MOVE:
                Move();
                break;

            case game_Smode.MAIN:
                Fight.SetActive(false);
                Canbas.SetActive(false);
                ClearCanbas.SetActive(false);
                break;

            case game_Smode.CLEAR:
                Clear();
                break;
        }
    }

    public void title()
    {
        switch (Kasor)
        {
            case sentaku.up:
                C_kari.y = ytyousei_S;
                break;

            case sentaku.midle:
                C_kari.y = ytyousei_C;
                break;

            case sentaku.down:
                C_kari.y = ytyousei_E;
                break;
        }
        C_kari.x = Kaxolx;
        r_arrow.transform.position = C_kari;
    }

    public void Move()
    {
        C_kari = Canbas.transform.position;
        C_kari.y += 4.0f;
        Canbas.transform.position = C_kari;
        FIGHTCNT++;

        if (FIGHTCNT > 110)
        {
            C_kari = Fight.transform.position;
            C_kari.y += 4.0f;
            C_kari.x = Kaxolx + 200.0f;
            Fight.transform.position = C_kari;
        }
    }

    public void Clear()
    {
        ClearCanbas.SetActive(true);
        if (PlayerMng.GetComponent<_GameMng>().win)
        {
            B_win.SetActive(true);
        }
        else
        {
            G_win.SetActive(true);
        }
    }

    public void Init()
    {
        Canbas.SetActive(true);
        Canbas.transform.position = new Vector3(512.0f, 384.0f, 0.0f);
        Fight.SetActive(true);
        Fight.transform.position = new Vector3(Kaxolx + 200.0f, -634.0f + 384.0f, 0.0f);
        ClearCanbas.SetActive(false);
        G_win.SetActive(false);
        B_win.SetActive(false);
        FIGHTCNT = 0;
    }
}