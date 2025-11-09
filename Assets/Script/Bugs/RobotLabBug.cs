using System.Collections;
using UnityEngine;

public class RobotLabBug : Bug
{
    [SerializeField]
    private GameObject fan;

    [SerializeField]
    private GameObject robotLabObjects;

    private int num;
    private int rotateSpeed = 100;
    private Vector3 rotateDirection = Vector3.left;

    private void Update()
    {
        FanRotate();
    }

    public override void Activate()
    {
        num = Random.Range(0, 2);
        switch (num)
        {
            case 0:
                rotateDirection = Vector3.forward;
                break;
            case 1:
                StartCoroutine(FlyObjet());
                break;
            default:
                break;
        }
    }

    public override void Deactivate()
    {
        switch (num)
        {
            case 0:
                fan.transform.localRotation = Quaternion.identity;
                rotateDirection = Vector3.left;
                break;
            case 1:
                StopAllCoroutines();
                robotLabObjects.transform.localPosition = Vector3.zero;
                break;
            default:
                break;
        }
    }

    private void FanRotate()
    {
        fan.transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }

    private IEnumerator FlyObjet()
    {
        while (true)
        {
            robotLabObjects.transform.position += Vector3.up * 0.1f * Time.deltaTime;
            yield return null;
        }
    }
}
