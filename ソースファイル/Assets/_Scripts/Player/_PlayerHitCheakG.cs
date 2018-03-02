using UnityEngine;

public class _PlayerHitCheakG : MonoBehaviour
{
    public GameObject PlayerB;       //攻撃対象.
    private float AddPo = 1.0f;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Attak_b_S")
        {
            if (PlayerB.GetComponent<_PlayerMove>().P_mode == EN_P_E_MODE.Attak)
            {
                if (GetComponent<_PlayerMove>().P_mode != EN_P_E_MODE.Damage)
                {
                    GetComponent<_PlayerMove>().PlayerDamage(PlayerB.transform, AddPo);
                }
            }
        }
    }
}