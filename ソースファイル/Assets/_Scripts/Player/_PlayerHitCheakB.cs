using UnityEngine;

public class _PlayerHitCheakB : MonoBehaviour
{
    public GameObject PlayerG;       //攻撃対象.
    private float AddPo = 1.0f;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Attak_S")
        {
            if (PlayerG.GetComponent<_PlayerMove>().P_mode == EN_P_E_MODE.Attak)
            {
                if (GetComponent<_PlayerMove>().P_mode != EN_P_E_MODE.Damage)
                {
                    GetComponent<_PlayerMove>().PlayerDamage(PlayerG.transform, AddPo);
                }
            }
        }
    }
}