using System.Collections;
using UnityEngine;

public class LightBug : Bug
{
    [SerializeField]
    private GameObject lights;

    private int num;

    private WaitForSeconds wait1 = new WaitForSeconds(1);
    private WaitForSeconds wait05 = new WaitForSeconds(0.5f);

    public override void Activate()
    {
        num = Random.Range(0, 3);

        switch (num)
        {
            case 0:
                StartCoroutine(OffLight());
                break;
            case 1:
                StartCoroutine(FadeOutLights());
                break;
            case 2:
                StartCoroutine(FlickerLight());
                break;
        }
    }

    public override void Deactivate()
    {
        switch (num)
        {
            case 0:
                StopAllCoroutines();
                lights.SetActive(true);
                break;
            case 1:
                StopAllCoroutines();
                for (int i = 0; i < lights.transform.childCount; i++)
                {
                    lights.transform.GetChild(i).gameObject.SetActive(true);
                }
                break;
            case 2:
                StopAllCoroutines();
                break;
        }

    }

    private IEnumerator OffLight()
    {
        yield return new WaitForSeconds(2.5f);
        lights.SetActive(true);
    }
    private IEnumerator FadeOutLights()
    {
        yield return new WaitForSeconds(2.5f);

        if (GameManager.Instance.IsStartRoom)
        {
            for (int i = 0; i < lights.transform.childCount; i++)
            {
                yield return wait1;
                lights.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = lights.transform.childCount - 1; i >= 0; i--)
            {
                yield return wait1;
                lights.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator FlickerLight()
    {
        yield return new WaitForSeconds(2.5f);

        while (true)
        {

            lights.SetActive(false);
            yield return wait05;
            lights.SetActive(true);
            yield return wait05;
        }
    }
}