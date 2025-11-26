using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHIt : MonoBehaviour
{
    private int hitCount = 0;
    private Rigidbody rb;
    private Move movescript;

    [SerializeField] private GameObject gameOverImage; // drag RawImage here
    private CanvasGroup canvasGroup;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movescript = GetComponent<Move>();

        if (gameOverImage != null)
        {
            gameOverImage.SetActive(false);  // hide at start
            canvasGroup = gameOverImage.GetComponent<CanvasGroup>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitCount++;
        Debug.Log("Player has collided " + hitCount + " times");

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeColor(collision.gameObject, Color.black);
            GameOver();
        }
    }

    private void ChangeColor(GameObject gameObject, Color color)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        material.color = color;
    }

    private bool GameOver()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        movescript.enabled = false;

        // show game over image
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true);

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                StartCoroutine(FadeIn(canvasGroup, 1f)); // fade in 1 sec
            }
        }

        // restart after 3 seconds
        Invoke("RestartGame", 3f);
        return true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private System.Collections.IEnumerator FadeIn(CanvasGroup cg, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            cg.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        cg.alpha = 1;
    }
}
