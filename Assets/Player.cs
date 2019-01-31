using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text Score, HiScoreText;
	public int Life = 1, Points, HiScore;
	GameObject m_Bullet, m_Enemy;
	float TimeAttak, EnemyTime = 1;
	// Start is called before the first frame update
	void Start()
	{
		m_Bullet = GameObject.Find("Bullet");
		m_Enemy = GameObject.Find("Enemy");
	}

	// Update is called once per frame
	void Update()
	{
        HiScore = PlayerPrefs.GetInt("HiScore");
        Score.text = "SCORE:" + Points.ToString();
        HiScoreText.text = "HISCORE:" + HiScore.ToString();
        ShootNow();
		Enemy();
		Rotation();
        IsTimeToDie();
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Life--;
		}
	}
	void ShootNow()
	{
		TimeAttak -= Time.deltaTime;
		if (Input.GetMouseButtonDown(0) && TimeAttak <= 0)
		{
			GameObject Bullet = Instantiate(m_Bullet, transform.position, Quaternion.identity);
			Bullet.tag = "Clone";
			Bullet.GetComponent<BulletMove>().Speed = 3 * 3.333333f;
            Bullet.GetComponent<BulletMove>().Direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10));
			TimeAttak = 0.5f;
		}

	}
	
	void Enemy()
	{
		EnemyTime -= Time.deltaTime;
		if (EnemyTime <= 0)
		{
			GameObject EnemyClone = Instantiate(m_Enemy, (Random.insideUnitCircle.normalized*10), Quaternion.identity);		
			EnemyClone.GetComponent<Enemy>().MoveorNot = true;
			EnemyClone.GetComponent<Enemy>().ColorValue = Random.Range(0, 3);           
			EnemyTime = 1f;
		}
			
	}

	void Rotation()
	{
		Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 lookAt = mouseScreenPosition;

		float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

		float AngleDeg = (180 / Mathf.PI) * AngleRad;

		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

	}
    void IsTimeToDie()
    {
        if ((Life <= 0) && (Points > HiScore))
        {
            Salvatore();
            SceneManager.LoadScene(1);
        }
        if ((Life == 0) && (Points < HiScore))
        {
            SceneManager.LoadScene(1);
        }
    }
    void Salvatore()
    {
        PlayerPrefs.SetInt("HiScore", Points);
        PlayerPrefs.Save();
    }
}
