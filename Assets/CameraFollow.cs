using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -5);

    void Update()
    {
        transform.position = player.position + offset;
    }
}
