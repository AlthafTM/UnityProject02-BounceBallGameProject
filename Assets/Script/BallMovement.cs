using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public ParticleSystem death;
    private Rigidbody2D rb;
    private Vector2 dragStartPosition;
    private Vector2 dragEndPosition;
    private Vector2 dragDirection;
    private bool isDragging = false;
    public bool canShoot = true;
    private static int shotCount = 0;
    public int maxShots = 1;
    public float shootPower = 10f;
    public ScoreManager ScoreManager;

    [SerializeField] private AudioSource WallHit;
    [SerializeField] private AudioSource StopWallHit;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int Steps = 15;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (canShoot)
        {
            if (Application.isMobilePlatform)
            {
                HandleTouchInput();
            }
            else
            {
                HandleMouseInput();
            }
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

            if (hitCollider != null && (hitCollider.gameObject == gameObject || hitCollider.CompareTag("DragArea")))
            {
                isDragging = true;
                dragStartPosition = touchPosition;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isDragging)
            {
                dragEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dragDirection = (dragEndPosition - dragStartPosition).normalized;
                Trajectory();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                isDragging = false;
                Shoot();
                shotCount++;
                if (shotCount >= maxShots)
                {
                    SetCanShoot(false);
                }
                lineRenderer.positionCount = 0; // Clear the trajectory line after shooting
            }
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

                if (hitCollider != null && (hitCollider.gameObject == gameObject || hitCollider.CompareTag("DragArea")))
                {
                    isDragging = true;
                    dragStartPosition = touchPosition;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (isDragging)
                {
                    dragEndPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    dragDirection = (dragEndPosition - dragStartPosition).normalized;
                    Trajectory();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (isDragging)
                {
                    isDragging = false;
                    Shoot();
                    shotCount++;
                    if (shotCount >= maxShots)
                    {
                        SetCanShoot(false);
                    }
                    lineRenderer.positionCount = 0; // Clear the trajectory line after shooting
                }
            }
        }
    }

    void Shoot()
    {
        Vector2 shootDirection = -dragDirection;
        rb.linearVelocity = shootDirection * shootPower;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallHit.Play();
            ScoreManager.instance.WallScore();
        } else if (collision.gameObject.CompareTag("StopWall"))
        {
            StopWallHit.Play();
            // Stop the character's velocity upon collision
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            ScoreManager.instance.WallScore();
            maxShots++;
            canShoot = true;
        }
    }

    public void SetCanShoot(bool value)
    {
        if (value)
        {
            shotCount = 0; // Reset shot count if enabling shooting
        }
        canShoot = value;
    }

    public void DeathAnim()
    {
        death.Play();
    }

    void Trajectory()
    {
        Vector3[] positions = new Vector3[Steps];
        Vector2 startPosition = spawnPoint.position;
        Vector2 currentVelocity = -(dragDirection * shootPower);
        float timeIncrement = 0.09f;

        for (int i = 0; i < Steps; i++)
        {
            float t = i * timeIncrement;
            Vector3 pos = startPosition + currentVelocity * t;
            positions[i] = pos;
        }

        lineRenderer.positionCount = Steps;
        lineRenderer.SetPositions(positions);
    }
}
