using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float mouseSensitivity = 2f;

    [SerializeField]
    private float maxVerticalAngle = 70f;

    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;

    private float mouseX;
    private float mouseY;

    void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;

        // 초기 회전값 저장
        horizontalRotation = transform.localEulerAngles.y;
        verticalRotation = transform.localEulerAngles.x;
    }

    void Update()
    {
        // 마우스 입력 받기
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        // 수평 회전 (Y축 기준)
        horizontalRotation += mouseX;

        // 수직 회전 (X축 기준) - 제한 적용
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        // 회전 적용
        transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
