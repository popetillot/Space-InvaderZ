using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
	private Transform[] Invaders;
	private Transform invader;
	public Transform invader1Prefab;
	public Transform invader2Prefab;
	public Transform invader3Prefab;

	private bool goingRight= true;

	// Use this for initialization
	void Start ()
	{
		Invaders = new Transform[55];
		int index = 0;
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 11; j++)
			{
				if (i<1)
				{
					invader = Instantiate(invader3Prefab) as Transform;
					Invaders[index]= invader;
					Invaders[index].transform.position = new Vector3 (j * 2.3f - 3.5f, i * 2.3f, 3);
					index = index+1;
				}
				if (i>=1 && i<3)
				{
					invader = Instantiate(invader2Prefab) as Transform;
					Invaders[index]= invader;
					Invaders[index].transform.position = new Vector3 (j * 2.3f - 3.5f, i * 2.3f, 3);
					index = index+1;
				}
				if (i>=3)
				{
					invader = Instantiate(invader1Prefab) as Transform;
					Invaders[index]= invader;
					Invaders[index].transform.position = new Vector3 (j * 2.3f - 3.5f, i * 2.3f, 3);
					index = index+1;
				}
				invader.parent=transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i<55; i++) 
			{
				if (Invaders[i] != null)
					{
						if (goingRight == true) 
							{
								Invaders [i].transform.Translate (new Vector3 (0.3f, 0f, 0f));
							}
						if (goingRight == false) 
							{
								Invaders [i].transform.Translate (new Vector3 (-0.3f, 0f, 0f));
							}
					}
			}
	}

	public void moveInvadersCloser (bool right)
	{
		goingRight = !right;
		for (int i = 0; i<55; i++)
		{
			if (Invaders [i] != null)
				{
					Invaders [i].transform.Translate (0f, -0.5f, 0f);
				}
		}
	}

	public void destroyInvader (Transform invader)
	{
		for (int i = 0; i<55; i++) 
		{
				if (Invaders[i] == invader)
			{
				Destroy (invader.gameObject);
				Destroy (Invaders[i].gameObject);
			}
		}

	}
}
