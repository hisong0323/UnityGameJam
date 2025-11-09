using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoGameCoroutine());
    }

    private IEnumerator GoGameCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
