using UnityEngine;

public class projectileTrigger : MonoBehaviour
{
    public GameObject[] projectiles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject projectile in projectiles)
            {
                projectile.SetActive(true);
            }
        }
    }
}
