using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 3;
    private float lastTime;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lastTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.instance.gameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                GameManager.instance.gameStart = true;
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))    // ako ne kolidira sa ni jednim objektom
        {
            GameManager.instance.gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
        }

        if (Input.GetMouseButtonDown(0) && !GameManager.instance.gameOver)
        {
            SwitchDirection();
        }

        if (Time.time > lastTime)
        {
            lastTime = Time.time + 5;
            IncreaseSpeed();
        }
    }

    private void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void IncreaseSpeed()
    {
        speed++;
    }
}