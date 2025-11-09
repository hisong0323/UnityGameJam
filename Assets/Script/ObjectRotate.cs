using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField]
    private int rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
