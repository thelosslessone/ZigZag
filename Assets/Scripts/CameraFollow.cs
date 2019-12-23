using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float lerpRate;
    private Vector3 offset;
    

    // Use this for initialization
    private void Start()
    {
        offset = target.transform.position - transform.position;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector3 position = transform.position;
        Vector3 targetPosition = target.transform.position - offset;
        position = Vector3.Lerp(position, targetPosition, lerpRate * Time.deltaTime);
        transform.position = position;
    }
}