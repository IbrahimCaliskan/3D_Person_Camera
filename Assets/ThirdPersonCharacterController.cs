using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] float moveSpeed = 6.0f;

    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;
        

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * Time.deltaTime * moveSpeed);
        }
    }
}
