using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class DeadRewardsScript : MonoBehaviour {

    public GameObject panel;
    CanvasGroup canvasGroup;
    Sequence fadeTextSequence;
    public Text goldText;
    public Text expText;

    EnemyController enemyController;

	// Use this for initialization
	

    void Awake()
    {
        canvasGroup = panel.GetComponent<CanvasGroup>();
        enemyController = gameObject.transform.parent.GetComponent<EnemyController>();
        fadeTextSequence = DOTween.Sequence();
        
    }

    void Start()
    {

        goldText.text = "+" + enemyController.MoneyCost + " Gold";
        expText.text = "+" + enemyController.ExpCost + " Exp";


    }

    void OnEnable()
    {
        FadeAnim();
    }

    void FadeAnim()
    {
        canvasGroup.alpha = 0;
        fadeTextSequence.Append(canvasGroup.DOFade(1, 3));
        fadeTextSequence.Join(panel.transform.DOLocalMoveY(50f, 1));
        fadeTextSequence.Append(canvasGroup.DOFade(0, 1));
    }


	// Update is called once per frame
	void Update () {
	
	}
}
