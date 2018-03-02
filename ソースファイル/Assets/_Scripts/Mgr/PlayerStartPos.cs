using UnityEngine;

public class PlayerStartPos : MonoBehaviour
{
    public enum lateral
    {
        RIGHT,
        LEFT,
    }

    private GameObject Stage;
    public lateral PosFlg;
    private Vector3 StageScale;
    public float STAGE_MAX;
    private Vector3 LastPos;
    private float TempX;
    private float TempZ;

    // Use this for initialization
    private void Start()
    {
        ClearPos();
    }

    public void StartPos()
    {
        Stage = GameObject.FindWithTag("Floor");
        StageScale = Stage.transform.localScale;
        STAGE_MAX = StageScale.x * StageScale.z;
        switch (PosFlg)
        {
            case lateral.RIGHT:
                TempX = StageScale.x / 4;
                break;

            case lateral.LEFT:
                TempX = -1 * StageScale.x / 4;
                break;
        }
        TempZ = 0.0f;
        LastPos = new Vector3(TempX, 0.0f, TempZ);
        transform.position = LastPos;
    }

    public void ClearPos()
    {
        transform.position = new Vector3(-0.05935378f, 0.0f, -1.464567f);
    }
}