using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadRewardsScript : MonoBehaviour {

    public GameObject panel;
    CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {

        

	}

    void Awake()
    {
        canvasGroup = panel.GetComponent<CanvasGroup>();
        
    }
	
    void OnEnable()
    {
        canvasGroup.alpha = 0;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(HideText());
    }
    IEnumerator HideText()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
