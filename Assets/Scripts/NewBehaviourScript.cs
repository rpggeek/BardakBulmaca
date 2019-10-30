using System.Collections;using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {

	public GameObject bardak1; 
	public GameObject bardak2;
	public GameObject top;

	public Vector2 obje1;
	public Vector2 obje2;
	public Vector2 anaObje;
	public Vector2 data;
	public bool tiklama = false;
	public int rastgele;
	public int hiz = 0;
	public int sayi = 0;
	public static float timer = 0;
	public int skor = 0;
	public int tıklama = 0;

	public static bool zeminde = false;
	public bool yerinialdi = false;
	public bool dugme = false;
	public Text score = null;

	AudioClip clip;
	AudioSource audioSource;

	Rigidbody2D rigid;

	static List<GameObject> liste = new List<GameObject> ();

	void Start () {
		top = GameObject.Find ("top");

		bardak1 = GameObject.Find ("bardak1");
		bardak2 = GameObject.Find ("bardak2");

		obje1 = bardak1.transform.position;
		obje2 = bardak2.transform.position;
		liste.Add (bardak1);
		liste.Add (bardak2);
		rigid = GetComponent<Rigidbody2D> ();

		audioSource = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void hareketettir(){
		timer += Time.deltaTime; // Bardakların ayarlanan zaman süresince ,aktif kalmasını sağlar.
		if (timer < 10) {
			if (transform.position.x != liste [rastgele].transform.position.x) {
				if (rastgele == 0) {

					data = obje1;
				}
				if (rastgele == 1) {

					data = obje2;
				}
				transform.position = Vector2.MoveTowards (transform.position, data, (25+hiz)* Time.deltaTime);
				liste [rastgele].transform.position = Vector2.MoveTowards (liste [rastgele].transform.position, anaObje, (25+hiz) * Time.deltaTime);
			} 
			if (transform.position.x == obje1.x) {
				GetComponent<AudioSource>().Play();
				yerinialdi= true;
				if (yerinialdi == true && timer > 6) {
					timer = 10;
				}
				Vector2 vector = anaObje;
				anaObje = obje1;
				obje1 = vector;
				rastgele = Random.Range (0, 2);
			}
			if (transform.position.x == obje2.x) {
				GetComponent<AudioSource>().Play();
				yerinialdi= true;
				if (yerinialdi == true && timer > 6) {

					timer = 10;
				}
				Vector2 vector = anaObje;
				anaObje = obje2;
				obje2 = vector;
				rastgele = Random.Range (0, 2);
			}
		}
	}
	// Üzerine tıklandığında,eğer top olan bardak ise TEBRıKLER yazısı dönecek.
	void Update () {
		if (zeminde) {
			if(zeminde && dugme == false) anaObje = transform.position;
			dugme = true;
			hareketettir ();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			{
				timer = 0;
				tıklama = 0;
			}
		}
		if (skor%5 ==0 && Input.GetMouseButtonDown(0) && hiz <= 20) {

			hiz += 1;
		}
	}

	// Zeminde olup olmadığını kontrol eden,eğer zemindeyse true döndüren fonksiyon
	void OnCollisionEnter2D(Collision2D collision)
	{
		zeminde = true;
		top.SetActive (false);
	}
	void OnMouseDown(){
		tiklama = true;
		if (tıklama == 0 && tiklama) {
			skor += 5;
			score.text = skor.ToString ();
			top.SetActive (true);
			GetComponent<AudioSource> ().Play ();
			rigid.AddForce (Vector2.up * 600);
		}
		tıklama++;
	}

}