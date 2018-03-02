using UnityEngine;

public class LightMgr : MonoBehaviour
{
    private game_Smode GameMode;
    private GameObject GameMgr;
    private GameObject[] PlayerLight;
    private GameObject ClearLight;

    // Use this for initialization
    private void Start()
    {
        GameMgr = GameObject.FindWithTag("GameMgr");
        PlayerLight = GameObject.FindGameObjectsWithTag("PlayerLight");
        ClearLight = GameObject.FindWithTag("ClearLight");
    }

    // Update is called once pear frame
    private void Update()
    {
        GameMode = GameMgr.GetComponent<_GameMng>().gameSmode;

        switch (GameMode)
        {
            case game_Smode.TITLE:
                for (int i = 0; i < PlayerLight.Length; i++)
                {
                    PlayerLight[i].SetActive(true);
                }
                ClearLight.SetActive(false);
                break;

            case game_Smode.MOVE:
                for (int i = 0; i < PlayerLight.Length; i++)
                {
                    PlayerLight[i].SetActive(true);
                }
                ClearLight.SetActive(false);
                break;

            case game_Smode.MAIN:
                for (int i = 0; i < PlayerLight.Length; i++)
                {
                    PlayerLight[i].SetActive(true);
                }
                ClearLight.SetActive(false);
                break;

            case game_Smode.CLEAR:
                for (int i = 0; i < PlayerLight.Length; i++)
                {
                    PlayerLight[i].SetActive(false);
                }
                ClearLight.SetActive(true);
                break;

            default:
                break;
        }
    }
}