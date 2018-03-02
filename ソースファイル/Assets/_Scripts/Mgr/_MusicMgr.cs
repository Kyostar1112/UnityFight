using System.Collections.Generic;
using UnityEngine;

public class _MusicMgr : MonoBehaviour
{
    private AudioSource AuSo;
    public List<AudioClip> Bgm = new List<AudioClip>();
    private game_Smode GameSMode;
    public GameObject Manager;
    private bool TitleFlg;
    private bool MainFlg;
    private bool ClearFlg;

    // Use this for initialization
    private void Start()
    {
        TitleFlg = true;
        MainFlg = true;
        ClearFlg = true;
        AuSo = GetComponent<AudioSource>();
        //AuSo.volume = 0.25f;
    }

    // Update is called once per frame
    private void Update()
    {
        GameSMode = Manager.GetComponent<_GameMng>().gameSmode;
        switch (GameSMode)
        {
            case game_Smode.TITLE:
                if (TitleFlg)
                {
                    AuSo.clip = Bgm[0];
                    AuSo.Play();
                    //AuSo.Stop();
                    TitleFlg = false;
                    MainFlg = true;
                    ClearFlg = true;
                }

                break;

            case game_Smode.MAIN:
                if (MainFlg)
                {
                    AuSo.clip = Bgm[1];
                    AuSo.Play();
                    TitleFlg = true;
                    MainFlg = false;
                    ClearFlg = true;
                }
                break;

            case game_Smode.CLEAR:
                if (ClearFlg)
                {
                    AuSo.clip = Bgm[2];
                    AuSo.Play();
                    TitleFlg = true;
                    MainFlg = true;
                    ClearFlg = false;
                }
                break;
        }
    }
}