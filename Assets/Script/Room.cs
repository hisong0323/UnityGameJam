using System.Collections;
using TMPro;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Door[] doors;

    [SerializeField]
    private GameObject interactionUI;

    [SerializeField]
    private bool isStartRoom;

    [SerializeField]
    private TextMeshPro[] scoreText;

    private bool isInteraction = false;

    private bool isLoad = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInteraction && !isLoad)
        {
            Use();
        }
    }

    private void Use()
    {
        StartCoroutine(UseCoroutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionUI.SetActive(true);
            isInteraction = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionUI.SetActive(false);
            isInteraction = false;
        }
    }

    private IEnumerator UseCoroutine()
    {
        isLoad = true;

        doors[0].Open();
        doors[1].Open();

        GameManager.Instance.ChangeRoom(isStartRoom);

        yield return new WaitForSeconds(0.5f);

        isLoad = false;
    }

    public void ChangeScoreText(int score)
    {
        scoreText[0].text = score.ToString();
        scoreText[1].text = score.ToString();
    }
}
