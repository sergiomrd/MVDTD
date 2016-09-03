using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// Class that handle the Enemy Behavior
/// </summary>
public class EnemyController : MonoBehaviour {

    // Enum for the state of the Enemy
	public enum EnemyStates 
	{
		Walk,
		MeleeAttack,
        Dead
	}

    // Canvas for the reward gained when the enemy is killed
    public Canvas rewardCanvas;

	[SerializeField]
	private EnemyStates currentState;

    // Property for the current state of the enmy
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

    // Render of the enemy
	private SpriteRenderer enemyRender;

    // Rigidbody of the enemy
    private Rigidbody rb;

    // This marks the enemy to attack
    [SerializeField]
	private TurretController enemyToAttack;

	[SerializeField]
	private float attackRate = 5;
	private float currentAttackRate;

	[SerializeField]
	private int meleeAttackDamage = 40;

    // How much does the player gain in money when this enemy is killed
	[SerializeField]
	private int moneyCost;

	public int MoneyCost {
		get {
			return moneyCost;
		}
	}


    [SerializeField]
    private int expCost;

    // How much does the player gain in experience when this enemy is killed
    public int ExpCost
    {
        get
        {
            return expCost;
        }
    }

	[SerializeField]
	private int maxLife = 100;

	[SerializeField]
	private int currentLife;

    // Property of the current life of the enemy. If the current life is 0, call the isKilled method
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

	

	// Use this for initialization
    // Initialice the components, the life and the Attack Rate
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		enemyRender = GetComponent<SpriteRenderer> ();
		currentLife = maxLife;
		currentAttackRate = attackRate;

	}
	
	// Update is called once per frame
    // On FixedUpdate check and change the states of our enemy for movement
	void FixedUpdate () {

		switch (currentState) 
		{
			case EnemyStates.Walk:
			
				MoveCharacter ();

				break;

		}
	
	}

    // On Update checks and change the states of our enemy for different actions 
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


         case EnemyStates.Dead:

            rewardCanvas.gameObject.SetActive(true);

            break;
        }
	}

    // This method moves the character to the position that is facing
	void MoveCharacter()
	{
		// Speed movement of the Rigidbody
		Vector3 movement = Vector3.left * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	}

    // This method handle the enemy attack. Every attack rate, the enemy turret marked takes damage.
	void MeleeAttack()
	{
		currentAttackRate -= Time.deltaTime;
		if (currentAttackRate <= 0) 
		{
			enemyToAttack.TakeDamage (meleeAttackDamage);
			currentAttackRate = attackRate;
		}

	}

    // Method that makes the current enemy get damage from the turrets attacks
	public void TakeDamage(int damage)
	{
		CurrentLife -= damage;
		StartCoroutine (ChangeHitColor ());

	}

    // Coroutine that handles that the enemy currently hit changes color
	IEnumerator ChangeHitColor()
	{

		Color startColor = enemyRender.color;

		enemyRender.color = Color.red;

		yield return new WaitForSeconds(0.05f);

		enemyRender.color = startColor;
	}

    // This method gives the money to the player
	void GiveMoneyToThePlayer()
	{
		GameManagerController.Instance.Money += moneyCost;
	}

    // When the current health is 0 the state of the enemy changes to dead, gives the money of the current enemy dead toteh player and start
    // the coroutine 
	void isKilled()
	{
        currentState = EnemyStates.Dead;
        GiveMoneyToThePlayer ();
        StartCoroutine(EnemyDestroyed());
	}

    void hasReachedTheEnd()
    {
        GameManagerController.Instance.Lives -= 1;
        Destroyed();
    }

    void Destroyed()
    {
        gameObject.SetActive(false);
    }

    IEnumerator EnemyDestroyed()
    {
        yield return new WaitForSeconds(2);
        rewardCanvas.gameObject.SetActive(false);
        gameObject.SetActive(false);

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
            hasReachedTheEnd();
        }

    }
}
