using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystickController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick; // переменная для виртуального джойстика
    [SerializeField] private float moveSpeed = 5f; // скорость движения персонажа
    [SerializeField] private float rotateSpeed = 5f; // скорость разворота персонажа
    [SerializeField] private Collider boundary; // граница, которую персонаж не может пересечь

    private Rigidbody rb;
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // получаем входные данные с виртуального джойстика
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // создаем вектор направления для движения объекта
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // нормализуем вектор направления и умножаем на скорость движения
        Vector3 targetVelocity = direction.normalized * moveSpeed;

        // плавное изменение скорости движения
        velocity = Vector3.Lerp(velocity, targetVelocity, Time.deltaTime * 10f);

        // применяем скорость к Rigidbody объекта
        rb.velocity = velocity;

        // поворачиваем объект в сторону движения
        if (velocity.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
        }

        // ограничиваем движение персонажа границей
        if (boundary != null)
        {
            Vector3 clampedPosition = boundary.ClosestPoint(transform.position);
            clampedPosition.y = transform.position.y;
            transform.position = clampedPosition;
        }
    }
}
