using UnityEngine;

public class BugManager : MonoBehaviour
{
    public static BugManager Instance;

    [SerializeField]
    private Bug[] bugs;

    private int bugNum;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateBug()
    {
        int randomInt = Random.Range(0, bugs.Length);

        if (bugNum == randomInt)
        {
            ActivateBug();
            return;
        }

        bugNum = randomInt;
        bugs[bugNum].Activate();
    }

    public void DeActivateBug()
    {
        bugs[bugNum].Deactivate();
    }
}
