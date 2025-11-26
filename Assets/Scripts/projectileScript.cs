using UnityEngine;

public class projectileScript : MonoBehaviour
{

    public Transform player;
    public float speed;
    private Vector3 playerPosition;

    private void Awake()
    {
        gameObject.SetActive(false);  
    }
    private void Start()
    {
        playerPosition = player.position;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
