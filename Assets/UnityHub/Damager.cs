using UnityEngine;

namespace Plugins.Runtime
{
	public class Damager : MonoBehaviour
	{

		//플레이어에게 데미지를 주는 클래스

		private GameObject shield;
		private GameObject sword;

		private void Start()
		{
			shield = GameObject.Find("Shield");
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Player")
			{

				PlayerController playerController = collision.GetComponent<PlayerController>();
				if (playerController != null && playerController.shield.active == false &&
				    playerController.Super.active == false && playerController.Ishield.active == false)
				{
					playerController.hp -= 1;
					playerController.onDamage();
					playerController.damageMotion();
					playerController.Super.SetActive(true);
				}

			}
		}
	}
}
	
