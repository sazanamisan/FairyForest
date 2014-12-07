using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public GameObject laser;
	public GUIText time;
	public GUIText setumei;
	public GUIText clear;
	public GameObject cleartext;
	public GUIText clear1;
	public GameObject cleartext1;
	public GUIText setumei2;

	public GameObject obj;

	private float score;
	private Transform enemy;
	private int hit_score;


	void Start()
	{
		setumei.text = "3秒当て続けると消滅";
		setumei2.text = "「A」か「D」キーで回転";
		score = 0.0f;
		hit_score = 0;
		time.text = score.ToString();
	}

	void Update()
	{
		RaycastHit hit;

		if (Physics.Raycast(laser.transform.position, laser.transform.forward, out hit))
		{
			if(hit.collider.tag == "Enemy")
			{
				score += Time.deltaTime;
				if(score >= 2.2){
					Instantiate (obj, hit.point, Quaternion.identity);
					//hit.collider.gameObject.transform.positionでもいいよ
					Destroy(hit.collider.gameObject);
					audio.Play();
					hit_score += 1;			
				}
			}
			if(hit.collider.tag == "Test")
			{
				score = 0.0f;
			}
		}

		time.text = Mathf.CeilToInt(score).ToString();

		if(hit_score == 5){
			clear.text = "やったぜ！";
			clear1.text = "Rキーでもう一回遊べるドン";
			cleartext.SetActive(true);
			cleartext1.SetActive(true);

			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		
		}


	}
}
