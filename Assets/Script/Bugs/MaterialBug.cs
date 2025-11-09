using System.Collections;
using UnityEngine;

public class MaterialBug : Bug
{
    [SerializeField]
    private Material[] materials;

    private void Awake()
    {
        Deactivate();
    }

    public override void Activate()
    {
        StartCoroutine(ActivateCoroutine());
    }

    public override void Deactivate()
    {
        StopAllCoroutines();
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = Color.white;
        }
    }

    private IEnumerator ActivateCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < materials.Length; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                materials[i].color = Color.blue;
            }
            else
            {
                materials[i].color = Color.red;
            }
        }
    }
}
