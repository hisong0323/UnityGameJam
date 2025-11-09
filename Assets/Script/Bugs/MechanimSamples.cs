using UnityEngine;

public class MechanimSamples : Bug
{
    [SerializeField]
    private GameObject charactors;

    private int rotateSpeed = 300;

    [SerializeField]
    private bool isRotate = false;

    [SerializeField]
    private bool isActive = false;

    private void Update()
    {
        if (isRotate)
            charactors.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
        
    public override void Activate()
    {
        isActive = true;
    }

    public override void Deactivate()
    {
        isActive = false;
        charactors.transform.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.gameObject.tag == "Player")
        {
            isRotate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive && other.gameObject.tag == "Player")
        {
            isRotate = false;
        }
    }
}
