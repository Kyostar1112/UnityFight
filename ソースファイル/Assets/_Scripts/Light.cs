using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject Target;
    private Vector3 Tmp;
    private Vector3 Temp;
    private float Height = 10;

    // Update is called once pear frame
    private void Update()
    {
        Tmp = Target.transform.position;
        Temp = Tmp;
        Tmp = new Vector3(Temp.x, Temp.y + Height, Temp.z);
        transform.position = Tmp;
    }
}