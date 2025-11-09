using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private float inputHorizontal;
    private float inputVertical;

    private float timer = 1;
    private float time = 0.8f;

    private bool isMove;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (isMove && timer >= time)
        {
            timer = 0;
            audioSource.Play();
        }
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
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    private void Move()
    {
        Vector3 moveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;

        Vector3 movement = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= 1.5f;
            time = 0.5f;
        }
        else
        {
            time = 0.8f;
        }

        transform.Translate(movement, Space.World);
    }
}
