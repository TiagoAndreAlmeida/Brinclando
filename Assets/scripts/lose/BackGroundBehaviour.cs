using UnityEngine;
using System.Collections;

public class BackGroundBehaviour : MonoBehaviour {
	
	public Sprite[] spritesPlayer = new Sprite[5];
	public Sprite[] spritesEnemy  = new Sprite[4];

	public SpriteRenderer spriteRendererPlayer, spriteRendererEnemy;
	
	string currentSpritePlayer, currentSpriteEnemy;
	
	// Use this for initialization
	void Awake () {
		
		currentSpritePlayer = PlayerPrefs.GetString ("roupa");
		currentSpriteEnemy = PlayerPrefs.GetString ("lixo");
		
	}
	
	// Update is called once per frame
	void Start () {

		switch(currentSpritePlayer){
			case "papel":
				spriteRendererPlayer.sprite = spritesPlayer[0];
			break;

			case "plastico":
				spriteRendererPlayer.sprite = spritesPlayer[1];
			break;

			case "metal":
				spriteRendererPlayer.sprite = spritesPlayer[2];
			break;

			case "vidro":
				spriteRendererPlayer.sprite = spritesPlayer[3];
			break;

			case "":
				spriteRendererPlayer.sprite = spritesPlayer[4];
			break;
		}

		switch(currentSpriteEnemy){
			case "papel":
				spriteRendererEnemy.sprite = spritesEnemy[0];
			break;

			case "plastico":
				spriteRendererEnemy.sprite = spritesEnemy[1];
			break;

			case "metal":
				spriteRendererEnemy.sprite = spritesEnemy[2];
			break;

			case "vidro":
				spriteRendererEnemy.sprite = spritesEnemy[3];
			break;

		}
		
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)) {}
		
		for(int i = 0; i<Input.touches.Length; i++){
			
			Touch touch = Input.touches[i];
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit = new RaycastHit();
			
			if(Physics.Raycast(ray, out hit, 100f)){
				if(hit.collider.name == "replay"){
					switch(touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(1);
						break;
					}
				}
				if(hit.collider.name == "exit"){
					switch(touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(0);
						break;
					}
				}
		
			}
		}
	}
}