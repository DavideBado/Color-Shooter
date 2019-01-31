using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	GameObject m_Camera, m_Player;
	public Rigidbody rb;
	public float Speed;
	public bool MoveorNot;
    public Vector3 Direction;
   
	// Start is called before the first frame update
	void Start()
	{       
        m_Player = GameObject.Find("Player");
		m_Camera = GameObject.Find("Main Camera");
		rb = GetComponent<Rigidbody>();
		MoveorNot = false;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			m_Camera.GetComponent<Camera>().backgroundColor = other.gameObject.GetComponent<Renderer>().material.color;
			m_Player.GetComponent<Player>().Points++;
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	private void Move()
	{
		if (tag == "Clone")

        {
            transform.position = Vector3.MoveTowards(transform.position, 10*Direction, Speed*Time.deltaTime);
        }
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
