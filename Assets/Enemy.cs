using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	GameObject m_player;
	Renderer rend;
	public Material[] materials;
	public int ColorValue;
	public float Speed;
    public bool MoveorNot;
	// Start is called before the first frame update
	void Start()
    {		
		rend = GetComponent<Renderer>();
		m_player = GameObject.Find("Player");		
    }

    // Update is called once per frame
    void Update()
    {
		Colore();
		Rotation();
		Move();
	}
	void Rotation() 
	{

		Vector3 lookAt = m_player.transform.position;

		float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}
	void Colore()
	{		
		rend.sharedMaterial = materials[ColorValue];
	}
	private void Move()
	{
        if (MoveorNot == true)
        {Speed = 3.333333f;
            if (rend.material.color != Camera.main.backgroundColor)
            {
                transform.position = (Vector3.MoveTowards(transform.position, m_player.transform.position, Speed * Time.deltaTime));
            }
            else if (rend.material.color == Camera.main.backgroundColor)
            {
                transform.position = (Vector3.MoveTowards(transform.position, m_player.transform.position, 2*Speed * Time.deltaTime));
            }
        }
	}

}
