using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Room startRoom;

    [SerializeField]
    private Room endRoom;

    [SerializeField]
    private Transform player;

    private bool isBug = false;
    private bool isStartRoom = true;

    private Transform targetRoom;
    private Transform currentRoom;
    private int score;
    private float bugChance = 0.3f;
    public bool IsStartRoom => isStartRoom;

    private void Awake()
    {
        Instance = this;
        currentRoom = endRoom.transform;
        targetRoom = startRoom.transform;
    }

    private void Setting()
    {
        BugManager.Instance.DeActivateBug();
        if (Random.Range(0, 1f) > bugChance)
        {
            bugChance = 0.3f;
            isBug = true;
            BugManager.Instance.ActivateBug();
        }
        else
        {
            isBug = false;
            bugChance = 0.1f;
        }
    }

    public void ChangeRoom(bool isStartRoom)
    {
        this.isStartRoom = isStartRoom;

        TryAddScore();
        Setting();

        if (isStartRoom)
        {
            currentRoom = startRoom.transform;
            targetRoom = endRoom.transform;
        }
        else
        {
            currentRoom = endRoom.transform;
            targetRoom = startRoom.transform;
        }

        Vector3 localPos = currentRoom.InverseTransformPoint(player.position);
        Vector3 targetPos = targetRoom.TransformPoint(localPos);

        player.position = targetPos;
    }

    private void TryAddScore()
    {
        if (isBug)
        {
            if (targetRoom == startRoom.transform && isStartRoom)
            {
                AddScore();
            }
            else if (targetRoom == endRoom.transform && !isStartRoom)
            {
                AddScore();
            }
            else
            {
                LoseScore();
            }
        }
        else
        {
            if (targetRoom == startRoom.transform && !isStartRoom)
            {
                AddScore();
            }
            else if (targetRoom == endRoom.transform && isStartRoom)
            {
                AddScore();
            }
            else
            {
                LoseScore();
            }
        }
        startRoom.ChangeScoreText(score);
        endRoom.ChangeScoreText(score);
    }

    private void AddScore()
    {
        if (score >= 8)
        {
            SceneManager.LoadScene(1);
        }
        score++;
    }

    private void LoseScore()
    {
        score = 0;
    }

}
