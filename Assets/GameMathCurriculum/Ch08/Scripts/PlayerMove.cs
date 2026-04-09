using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private static readonly string horizontal = "Horizontal";
    private static readonly string vertical = "Vertical";

    private Vector3 move;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float rotateSpeed = 45f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis(horizontal), 0f, Input.GetAxis(vertical)).normalized;
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
    }
}
