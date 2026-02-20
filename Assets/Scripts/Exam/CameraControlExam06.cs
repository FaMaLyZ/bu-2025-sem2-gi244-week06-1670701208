using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offsetZ;
    public float offsetX;
    public Vector3 offset;
    public Camera targetCamera;

    // Update is called once per frame
    private void Update()
    {
        offsetZ = player2.transform.position.z - player1.transform.position.z;
        offsetX = player2.transform.position.x - player1.transform.position.x;

        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;
        offset = (player2Pos) + player1Pos;
    }
    void LateUpdate()
    {
       


        // Student code ...
        targetCamera.orthographicSize = offsetX;
        if (offsetZ >= offsetX)
        {
            targetCamera.orthographicSize = offsetZ;
        }
        targetCamera.transform.position = new Vector3(offset.x, targetCamera.transform.position.y, offset.z);
    }
}
