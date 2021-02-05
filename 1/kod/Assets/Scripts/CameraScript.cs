using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    public UnityEngine.Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position;
    }

    // Update is called once per frame
    void LastUpate()
    {
        transform.position = Player.transform.position + Offset;
    }
}
