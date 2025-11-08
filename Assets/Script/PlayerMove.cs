using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private float inputHorizontal;
    private float inputVertical;

    private void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        Vector3 moveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;

        Vector3 movement = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        transform.Translate(movement, Space.World);
    }
}
