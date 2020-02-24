using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Runtime
{
	public class Sword : MonoBehaviour
	{

		public Slider gage; //슬라이더
		public GameObject bar; //gage의 실체 오브젝트
		
		private GameObject player;
		private SpriteRenderer pf; //플레이어의 filp을 사용하기 위해 선언
		private SpriteRenderer sf; //아이템의 플립을 사용하기 위해 선언
		private Animator ani;
		private Rigidbody2D pR; //플레이어의 돌진을 위해 선언
		private CircleCollider2D cir; //게이지가 다 찼을때만 활성화하기 위해 선언

		void Awake()
		{
			player = GameObject.Find("Player");
			pf = player.GetComponent<SpriteRenderer>();
			sf = GetComponent<SpriteRenderer>();
			ani = GetComponent<Animator>();
			pR = player.GetComponent<Rigidbody2D>();
			cir = GetComponent<CircleCollider2D>();
		}

		private void OnEnable()
		{
			cir.enabled = false;
			bar.SetActive(true);
			gage.value = 0;
			StartCoroutine(UpGage());

		}


// Update is called once per frame
		void Update()
		{
			if (pf.flipX == true)
			{
				sf.flipX = true;
			}
			else
			{
				sf.flipX = false;
			}
		}

		IEnumerator UpGage()
		{
			while (gameObject.active == true)
			{
				while (gage.value < 1.0f)
				{
					gage.value += 0.01f;
					yield return new WaitForSeconds(0.1f); //10초
				}

				if (gage.value == 1)
				{
					cir.enabled = true;
					ani.SetTrigger("Shot");

					yield return new WaitForSeconds(0.5f);
					pR.velocity = new Vector2(0, 30f);
					yield return new WaitForSeconds(0.2f);
					ani.SetTrigger("End");
					ani.SetTrigger("Idle");
					yield return new WaitForSeconds(1f);
					cir.enabled = false;
					gage.value = 0f;
				}

			}
		}
	}
}