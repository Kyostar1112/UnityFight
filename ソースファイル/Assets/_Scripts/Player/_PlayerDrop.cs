using UnityEngine;

public class _PlayerDrop : MonoBehaviour
{
    public float D_cnt;
    private Rigidbody playerRigid;	//ﾌﾟﾚｲﾔｰのrigidbody用.
    public bool Drop;
    private Vector3 Force;

    // Use this for initialization.
    private void Start()
    {
        Drop = true;
        Force = new Vector3(0.0f, -10.0f, 0.0f);
        playerRigid = GetComponent<Rigidbody>();    //ﾌﾟﾚｲﾔｰのRigidbodyを探し出す.
        D_cnt = 200.0f;
    }

    // Update is called once per frame.
    private void Update()
    {
        if (!Drop)
        {
            D_cnt--;
            playerRigid.AddForce(Force * 2.0f, ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            // 回転しない設定.
            playerRigid.constraints = RigidbodyConstraints.None;
            Drop = false;
        }
    }
}