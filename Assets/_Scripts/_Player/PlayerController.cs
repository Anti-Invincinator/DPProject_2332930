using UnityEngine;


public class PlayerController : MonoBehaviour
{

    #region Singleton
    public static PlayerController _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
    #endregion //!Singleton

    public float moveSpeed = 5f;
    public Transform arrowSpawnPoint;
    public float maxArrowSpeed = 20f;
    public float minArrowSpeed = 5f;
    public float maxDrawTime = 1.5f;
    public Quiver quiver;
    public ObjectPooler arrowPooler;
    public float fireRate = 1f; // Time in seconds between shots

    private Vector2 movement;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private Camera cam;
    private bool isDrawing = false;
    private float drawTime = 0f;
    private float nextFireTime = 0f; // Time when the player can fire next

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        // Handle player movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Handle mouse position input
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Start drawing the bow when the left mouse button is pressed
        if (Input.GetButtonDown("Fire1") && quiver.HasArrows() && Time.time >= nextFireTime)
        {
            isDrawing = true;
            drawTime = 0f;
        }

        // Stop drawing the bow when the left mouse button is released and shoot the arrow
        if (Input.GetButtonUp("Fire1") && isDrawing)
        {
            isDrawing = false;
            Shoot();
            nextFireTime = Time.time + fireRate; // Set the next fire time based on the fire rate
        }

        // Increase draw time while holding the button
        if (isDrawing)
        {
            drawTime += Time.deltaTime;
            drawTime = Mathf.Clamp(drawTime, 0f, maxDrawTime);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotate the player to face the mouse cursor
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        // Calculate arrow speed based on draw time
        float arrowSpeed = Mathf.Lerp(minArrowSpeed, maxArrowSpeed, drawTime / maxDrawTime);

        // Get an arrow from the object pooler
        GameObject arrow = arrowPooler.GetPooledObject();
        if (arrow != null)
        {
            arrow.transform.position = arrowSpawnPoint.position;
            arrow.transform.rotation = arrowSpawnPoint.rotation;
            arrow.SetActive(true);

            // Set the arrow's velocity
            Rigidbody2D rbArrow = arrow.GetComponent<Rigidbody2D>();
            rbArrow.velocity = arrowSpawnPoint.up * arrowSpeed;

            // Use an arrow from the quiver
            quiver.UseArrow();
        }
        else
        {
            EnhancedLogger.Log("No More Knives!!", EnhancedLogger.LogLevel.Error);
        }
    }
}
