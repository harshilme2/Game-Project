using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private int count;
    public Text gemText;
    public Text winText;
    public int playerNo = 1;
    private Vector2 direction;

    [Header("Movement")]
    [Range(1, 20)]
    public float speed;

    [Space(10)]

    [Header("Dodge and Recover")]

    public float dodgeForce;
    [Range(-0.1f, 3f)]
    public float distanceToRecover;
    public float dodgeDrag;

    [Space(10)]

    private float defaultDrag;
    private Vector2 defaultBoxSize;
    private bool isDodging = false;

    [Space(10)]

    public Sprite normalSprite;
    public Sprite dodgeSprite;

    public float maxHealth;
    public float health;

    private Transform SlashAttack;
    public float slashDistance;
    private bool canMove = true;


    [Space(10)]
    [Header("Items")]

    public int timer;

    public int bombs;
    public int keys;

    private enum xdir
    {
        none,
        left,
        right
    }
    private xdir xDirection = xdir.none;
    private enum ydir
    {
        none,
        up,
        down
    }
    private ydir yDirection = ydir.up;


    //vars for the whole sheet
    public int colCount = 3;
    public int rowCount = 3;

    //vars for animation
    public int rowNumber = 0; //Zero Indexed
    public int colNumber = 0; //Zero Indexed
    public int totalCells = 8;
    public int fps = 24;

    private Renderer _renderer;
    private Vector2 offset;
    private bool canWalk;

    private void Start()
    {
        print("Hello");
        _renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        defaultDrag = rb.drag;

        health = maxHealth;
        //SlashAttack = transform.Find("SlashArea");
        //SlashAttack.gameObject.SetActive(false);

        //temporal items
        bombs = 0;
        keys = 0;
        UpdateHUD();
        //SetCountText();
    }

    static int Sign(float number)
    {
        return number < 0 ? -1 : (number > 0 ? 1 : 0);
    }


    void Update()
    {
        if (isDodging && Vector2.Distance(rb.velocity, Vector2.zero) < distanceToRecover)
        {
            isDodging = false; //return isDodging boolean to false
            rb.drag = defaultDrag; //restore normal linear Drag
            boxCollider.size = defaultBoxSize; // TODO: program proper dodging mechanics
            transform.localScale = Vector2.one; // return transform scale to 1,1

            spriteRenderer.sprite = normalSprite;

        }
        else if (isDodging)
        {
            //transform.localScale = new Vector2(2, 2);
            spriteRenderer.sprite = dodgeSprite;
        }

        if(health <= 0)
        {
            //destroy
            Destroy(this);
        }

        float horizontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");

        if (horizontalSpeed != 0 || verticalSpeed != 0) canWalk = true;
        else canWalk = false;

        if (horizontalSpeed > 0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            transform.Translate(Vector3.down * horizontalSpeed * Time.deltaTime * speed);
        }
        else if (horizontalSpeed < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            transform.Translate(Vector3.up * horizontalSpeed * Time.deltaTime * speed);
        }
        else if (verticalSpeed > 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime * speed);
        }
        else if (verticalSpeed < 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime * speed);
        }

        SetSpriteAnimation(colCount, rowCount, rowNumber, colNumber, totalCells, fps);
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    //SetSpriteAnimation
    void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
    {
        // Calculate index
        int index = (int)(Time.time * fps);

        // Repeat when exhausting all cells
        index = index % totalCells;

        // Size of every cell
        float sizeX = 1.0f / colCount;
        float sizeY = 1.0f / rowCount;
        Vector2 size = new Vector2(sizeX, sizeY);

        // split into horizontal and vertical index
        var uIndex = index % colCount;
        var vIndex = index / colCount;

        // build offset
        // v coordinate is the bottom of the image in opengl so we need to invert.
        float offsetX = (uIndex + colNumber) * size.x;
        float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;

        if (canWalk)
        {
            offset = new Vector2(offsetX, offsetY);
            _renderer.material.SetTextureOffset("_MainTex", offset);
        }
        _renderer.material.SetTextureScale("_MainTex", size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            print(collision.gameObject.name);
            Hurt(1);
        }
        if (collision.gameObject.tag == "spikes")
        {
            print(collision.gameObject.name);
            Hurt(1);
        }
        if (collision.gameObject.tag == "life")
        {
            print(collision.gameObject.name);
            Heal(collision.gameObject, 1);
        }

    }

    void Attack()
    {
        var atk = SlashAttack;
        atk.gameObject.SetActive(true);
        float atkPosX = 0;
        float atkPosY = 0;
        float atkDis = slashDistance;
        //atk.transform.localPosition = Vector2.zero;
        // if(xDirection == xdir.right){
        // 	atkPosX =  atkDis;
        // } else if(xDirection == xdir.left){
        // 	atkPosX = -atkDis;
        // }
        // if(yDirection == ydir.up){
        // 	atkPosY =  atkDis;
        // } else if(yDirection == ydir.down){
        // 	atkPosY = -atkDis;
        // }

        atk.transform.localPosition = (direction.normalized * atkDis);
        StartCoroutine(hideAtack(atk.gameObject));

    }
    private IEnumerator hideAtack(GameObject atk)
    {
        canMove = false;
        yield return new WaitForSeconds(0.3f);
        atk.SetActive(false);
        canMove = true;
    }
    public void UpdateHUD()
    {
        GameObject.Find("Player Panel").GetComponent<UIPlayerHUD>().UpdateHud();
    }
    public void Hurt(float dmg)
    {
        // health -= dmg;
        // if (health < 0) health = 0;
        // print("Health is:" + health);

        var hp = GetComponent<PlayerHealth>();
        hp.Hurt(dmg);

    }
    public void Heal(GameObject obj, float life)
    {
        // health -= dmg;
        // if (health < 0) health = 0;
        // print("Health is:" + health);

        var hp = GetComponent<PlayerHealth>();
        hp.Heal(obj, life);

    }
    //void SetCountText()
    //{
    //    gemText.text = "Count : " + count.ToString();
    //    // if (count >= 18)
    //    //   {
    //    //     winText.text = "Won";
    //    //  }
    //}


}
