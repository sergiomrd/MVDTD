using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Speed movement of the Enemy
	public float speedMovement;

	private SpriteRenderer enemyRender;

	[SerializeField]
	private int moneyCost;

	public int MoneyCost {
		get {
			return moneyCost;
		}
	}

	[SerializeField]
	private int maxLife = 100;

	[SerializeField]
	private int currentLife;

	public int CurrentLife {
		get {
			return currentLife;
		}
		set {
			currentLife = value;
			if (currentLife <= 0) 
			{
				Kill ();
			}
		}
	}

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		enemyRender = GetComponent<SpriteRenderer> ();
		currentLife = maxLife;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Speed movement of the Rigidbody
		Vector3 movement = Vector3.left * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	
	}

	public void Hit(int damage)
	{
		CurrentLife -= damage;
		StartCoroutine (ChangeHitColor ());

	}

	IEnumerator ChangeHitColor()
	{

		Color startColor = enemyRender.color;

		enemyRender.color = Color.red;

		yield return new WaitForSeconds(0.05f);

		enemyRender.color = startColor;
	}

	void GiveMoneyToThePlayer()
	{
		GameManagerController.Instance.Money += moneyCost;
	}

	void Kill()
	{
		GiveMoneyToThePlayer ();
		Destroy (gameObject);
	}
		
}
