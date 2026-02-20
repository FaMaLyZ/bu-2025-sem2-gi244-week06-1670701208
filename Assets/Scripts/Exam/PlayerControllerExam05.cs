using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    int bulletCount = 0;
    public float bulletRegenerateCooldown = 1f;
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            bulletCount++;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            if (bulletCount >= maxBulletCount)
            {
                Debug.Log("Reloading");
                StartCoroutine(Reload());
                shootAction.Disable();
            }
        }
    }
    private IEnumerator Reload()
    {

        yield return new WaitForSeconds(bulletRegenerateCooldown);
        Debug.Log("Finish");
        bulletCount = 0;
        shootAction.Enable();

    }
}
