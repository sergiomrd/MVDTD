using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public enum EnemyStates 
	{
		Walk,
		MeleeAttack
	}

	[SerializeField]
	private EnemyStates currentState;

	public EnemyStates CurrentState {
		get {
			return currentState;
		}
		set {
			currentState = value;
		}
	}

	// Speed movement of the Enemy
	public float speedMovement;

	private SpriteRenderer enemyRender;

	[SerializeField]
	private TurretController enemyToAttack;

	[SerializeField]
	private float attackRate = 5;
	private float currentAttackRate;

	[SerializeField]
	private int meleeAttackDamage = 40;

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
				isKilled ();
			}
		}
	}

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		enemyRender = GetComponent<SpriteRenderer> ();
		currentLife = maxLife;
		currentAttackRate = attackRate;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		switch (currentState) 
		{
			case EnemyStates.Walk:
			
				MoveCharacter ();

				break;
		}
	
	}

	void Update() {
		
		switch (currentState) 
		{
		case EnemyStates.MeleeAttack:
				
			if (enemyToAttack != null) 
			{
				MeleeAttack ();
			} 
			else 
			{
				CurrentState = EnemyStates.Walk;
			}

			break;
		}
	}

	void MoveCharacter()
	{
		// Speed movement of the Rigidbody
		Vector3 movement = Vector3.left * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}

	void MeleeAttack()
	{
		currentAttackRate -= Time.deltaTime;
		if (currentAttackRate <= 0) 
		{
			enemyToAttack.TakeDamage (meleeAttackDamage);
			currentAttackRate = attackRate;
		}

	}

	public void TakeDamage(int damage)
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

	void isKilled()
	{
		GiveMoneyToThePlayer ();
		Destroy (gameObject);
	}

    void hasReachedTheEnd()
    {
        GameManagerController.Instance.Lives -= 1;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.GetComponent<TurretController>())
        {
			CurrentState = EnemyStates.MeleeAttack;
			enemyToAttack = other.gameObject.GetComponent<TurretController>();
        }

        if(other.collider.gameObject.GetComponent<BoundaryFloor>())
        {
            Debug.Log("Enter");
            hasReachedTheEnd();
        }

    }
}
