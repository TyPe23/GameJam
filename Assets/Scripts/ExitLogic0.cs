using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLogic0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 2 Greybox");
        }
    }
}