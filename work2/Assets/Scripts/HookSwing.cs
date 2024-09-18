using UnityEngine;

public class HookSwing : MonoBehaviour
{
    public float leftAngle = -55f;
    public float rightAngle = 55f;

    public float rotationSpeed = 5f;
    public float shootingSpeed = 3f;

    private float rotateAngle;
    private bool rotateRight;
    private bool canRotate;

    private float initShootingSpeed;

    private float maxHookRetractY = -2.5f;
    private float initY;

    private bool isShooting;

    private ExtendRope rope;

    private void Awake()
    {
        rope = GetComponent<ExtendRope>();
    }

    private void Start()
    {
        initY = transform.position.y;
        initShootingSpeed = shootingSpeed;

        canRotate = true;
    }
    private void Update()
    {
        Rotate();
        GetKeyInput();
        ShootRope();
    }

    public void Rotate()
    {
        if (!canRotate)
        {
            return;
        }

        if (rotateRight)
        {
            rotateAngle += rotationSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle  -= rotationSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

        if (rotateAngle >= rightAngle)
        {
            rotateRight = false;
        }
        else if (rotateAngle <= leftAngle)
        {
            rotateRight = true;
        }
    }
    private void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canRotate)
            {
                canRotate = false;
                isShooting = true;
            }
        }
    }
    public void ShootRope()
    {
        if (canRotate)
        {
            return;
        }

        if (!canRotate)
        {
            Vector3 temp = transform.position;

            if (isShooting)
            {
                temp -= transform.up * Time.deltaTime * shootingSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * shootingSpeed;
            }

            transform.position = temp;

            if (temp.y <= maxHookRetractY)
            {
                isShooting = false;
            }

            if (temp.y >= initY)
            {
                canRotate = true;
                rope.RenderLine(temp, false);
                shootingSpeed = initShootingSpeed;
            }

            rope.RenderLine(transform.position, true);
        }
    }
}
