using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb;
    private int count;
    public Text gemText;
    public Text winText;
    public int playerNo = 1;

	[Header("Movement")]
	[Range(1,20)]
	public float movementSpeed;

	[Space(10)]
	
	[Header("Dodge and Recover")]

	public float dodgeForce;
	[Range(-0.1f,3f)]
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
	private float health;

	private Transform SlashAttack;
	public float slashDistance;
	private bool canMove = true;

	[Space(10)]
	[Header("Items")]

	public int bombs;
	public int keys;

	private enum xdir{
		none,
		left,
		right
	}
	private xdir xDirection = xdir.none;
	private enum ydir{
		none, 
		up, 
		down
	}
	private ydir yDirection = ydir.up;
	
	private Vector2 direction;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		boxCollider = GetComponent<BoxCollider2D>();

		defaultDrag = rb.drag;

		health = maxHealth;
		SlashAttack = transform.Find("SlashArea");
		SlashAttack.gameObject.SetActive(false);

		//temporal items
		bombs = 0;
		keys  = 0;
		UpdateHUD();
        SetCountText();
	}

	static int Sign(float number) {
      return number < 0 ? -1 : (number > 0 ? 1 : 0);
  	}
	
	void Update () {
		
		//Movement
		if(isDodging && Vector2.Distance(rb.velocity, Vector2.zero) < distanceToRecover ){
			isDodging = false; //return isDodging boolean to false
			rb.drag = defaultDrag; //restore normal linear Drag
			boxCollider.size = defaultBoxSize; // TODO: program proper dodging mechanics
			transform.localScale = Vector2.one; // return transform scale to 1,1

			spriteRenderer.sprite = normalSprite;

		} else if (isDodging){
			//transform.localScale = new Vector2(2, 2);
			spriteRenderer.sprite = dodgeSprite;
		}

		if (!isDodging){

			rb.velocity = Vector2.zero;

			if (canMove){
				if (Input.GetKey(KeyCode.A)){
					rb.velocity += Vector2.left * movementSpeed;
					xDirection = xdir.left;
					direction = Vector2.left;
				} else if (Input.GetKey(KeyCode.D)){
					rb.velocity += Vector2.right * movementSpeed;
					xDirection = xdir.right;
					direction = Vector2.right;
				} else {
					yDirection = ydir.none;
				}

				if(Input.GetKey(KeyCode.W)){
					rb.velocity += Vector2.up * movementSpeed;
					yDirection = ydir.up;
					direction = Vector2.up;
				} else if (Input.GetKey(KeyCode.S)){
					rb.velocity += Vector2.down * movementSpeed;
					yDirection = ydir.down;
					direction = Vector2.down;
				} else {
					yDirection = ydir.none;
				}

				if (Input.GetKeyDown(KeyCode.Space)){
					rb.velocity = new Vector2( Sign( rb.velocity.x ), Sign( rb.velocity.y ) ) * dodgeForce;
					rb.drag = dodgeDrag;
					defaultBoxSize = boxCollider.size;
					//boxCollider.size = Vector2.zero;
					isDodging = true;

				}
			}

			

			if (Input.GetKeyDown(KeyCode.J)){
				Attack();
			}
		}

	}

	void Attack(){
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
		
		atk.transform.localPosition = (direction.normalized*atkDis);
		StartCoroutine(hideAtack(atk.gameObject));
		
	}

	private IEnumerator hideAtack(GameObject atk){
		canMove = false;
		yield return new WaitForSeconds(0.3f);
		atk.SetActive(false);
		canMove = true;
	}

	public void UpdateHUD(){
		GameObject.Find("Player Panel").GetComponent<UIPlayerHUD>().UpdateHud();
	}

	public void Hurt(float dmg){
		// health -= dmg;
		// if (health < 0) health = 0;
		// print("Health is:" + health);

		var hp = GetComponent<PlayerHealth>();
		hp.Hurt(dmg);

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ruby") || other.gameObject.CompareTag("Diamond") || other.gameObject.CompareTag("Gem"))
        {

            Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        gemText.text = "Count : " + count.ToString();
       // if (count >= 18)
     //   {
       //     winText.text = "Won";
      //  }
    }
}
