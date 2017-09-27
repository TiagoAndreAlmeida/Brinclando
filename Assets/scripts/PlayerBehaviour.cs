using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	public string lastTrash, currentTrash;

	public float speed;
	public float sensibility;
	public float limitTop, limitDown, limitLeft, limitRigth;

	public Transform meshPlayer;
	public Transform top,topLeft,topRigth,down,downLeft,downRigth,left,rigth;

	public GameController gameController;
	public SpawnBehaviour spawnBehaviour;

	public GameObject nextParticules;
	public GameObject[] particulas = new GameObject[4];

	public Material nextMaterial;
	public Material[] materials = new Material[4];

	public Renderer PlayerMaterial;
	public Animator playerAnimator;

	public Text remaingTrash;
	public int trashs = 10;

	// Use this for initialization
	void Start () {
		remaingTrash.text = "Lixos restantes: " + trashs;
	}

	void Update () {
		if (trashs <= 0)
			gameController.SwitchState (stateMachine.WIN);
	}
	
	// Update is called once per frame
	public void MovePlayer () {

		if (gameController.GetStateMachine () == stateMachine.PLAY) {

			if (!(Input.acceleration.x > sensibility))
				playerAnimator.SetBool ("isStopped", true);
			else if (!(Input.acceleration.x < -sensibility))
				playerAnimator.SetBool ("isStopped", true);
			else if (!(Input.acceleration.y > sensibility))
				playerAnimator.SetBool ("isStopped", true);
			else if (!(Input.acceleration.y < -sensibility))
				playerAnimator.SetBool ("isStopped", true);


			if (Input.acceleration.x > sensibility) {

				playerAnimator.SetBool ("isStopped", false);

				if (Input.acceleration.y > sensibility) {
					SetRotation (topRigth);
				} else if (Input.acceleration.y < -sensibility) {
					SetRotation (downRigth);
				} else {
					SetRotation (rigth);
				}

				if (!Physics.Raycast (transform.position, Vector3.right, 0.5f)) {

					transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

				}
			}

			if (Input.acceleration.x < -sensibility) {

				playerAnimator.SetBool ("isStopped", false);

				if (Input.acceleration.y > sensibility) {
					SetRotation (topLeft);
				} else if (Input.acceleration.y < -sensibility) {
					SetRotation (downLeft);
				} else {
					SetRotation (left);
				}

				if (!Physics.Raycast (transform.position, Vector3.left, 0.5f)) {
				
					transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
				
				}

			}
			if (Input.acceleration.y > sensibility) {

				playerAnimator.SetBool ("isStopped", false);

				if (Input.acceleration.x > sensibility) {
					SetRotation (topRigth);
				} else if (Input.acceleration.x < -sensibility) {
					SetRotation (topLeft);
				} else {
					SetRotation (top);
				}

				if (!Physics.Raycast (transform.position, Vector3.forward, 0.5f)) {

					transform.position += new Vector3 (0, 0, speed * Time.deltaTime);

				}

			}
			if (Input.acceleration.y < -sensibility) {

				playerAnimator.SetBool ("isStopped", false);

				if (Input.acceleration.x > sensibility) {
					SetRotation (downRigth);
				} else if (Input.acceleration.x < -sensibility) {
					SetRotation (downLeft);
				} else {
					SetRotation (down);
				}
			
				if (!Physics.Raycast (transform.position, Vector3.back, 0.5f)) {
				
					transform.position += new Vector3 (0, 0, -speed * Time.deltaTime);
				
				}
			
			}

			if (transform.position.z > limitTop)
				transform.position = new Vector3 (transform.position.x, 0, limitTop);
			if (transform.position.z < limitDown)
				transform.position = new Vector3 (transform.position.x, 0, limitDown);
			if (transform.position.x < limitLeft)
				transform.position = new Vector3 (transform.position.z, 0, limitLeft);
			if (transform.position.x > limitRigth)
				transform.position = new Vector3 (transform.position.z, 0, limitRigth);

		}
	}

	/*private IEnumerator WaitAnySeconds () {
	
		yield return new WaitForSeconds (5);

	}*/

	public void SwitchClothes (GameObject colorOfSmoke, Material clothes){

		GameObject aux = Instantiate (colorOfSmoke, transform.position, Quaternion.identity) as GameObject;
		PlayerMaterial.material = clothes;
		//WaitAnySeconds();
		gameController.SwitchState (stateMachine.PLAY);
		Destroy(aux, 1);
		
	}

	void OnTriggerEnter(Collider hit){

		if(hit.tag == "metal"){

			lastTrash = currentTrash;
			currentTrash = hit.tag;
			nextParticules = particulas[0];
			nextMaterial = materials[0];
			gameController.SwitchState (stateMachine.SWITCHCLOTHES);
			Destroy(hit.gameObject);

		}
		if(hit.tag == "papel"){

			lastTrash = currentTrash;
			currentTrash = hit.tag;
			nextParticules = particulas[1];
			nextMaterial = materials[1];
			gameController.SwitchState (stateMachine.SWITCHCLOTHES);
			Destroy(hit.gameObject);

		}
		if(hit.tag == "plastico"){

			lastTrash = currentTrash;
			currentTrash = hit.tag;
			nextParticules = particulas[2];
			nextMaterial = materials[2];
			gameController.SwitchState (stateMachine.SWITCHCLOTHES);
			Destroy(hit.gameObject);

		}
		if(hit.tag == "vidro"){

			lastTrash = currentTrash;
			currentTrash = hit.tag;
			nextParticules = particulas[3];
			nextMaterial = materials[3];
			gameController.SwitchState (stateMachine.SWITCHCLOTHES);
			Destroy(hit.gameObject);

		}

		if(hit.tag == "lixoVidro"){
			if(currentTrash == "vidro"){
				Destroy(hit.gameObject);
				spawnBehaviour.SpawnNewEnemy(this.transform);
				trashs--;
				remaingTrash.text = "Lixos restantes: " + trashs;
			}else{
				PlayerPrefs.SetString("roupa",currentTrash);
				PlayerPrefs.SetString("lixo", "vidro");
				gameController.SwitchState(stateMachine.LOSE);
			}
		}

		if(hit.tag == "lixoPlastico"){
			if(currentTrash == "plastico"){
				Destroy(hit.gameObject);
				spawnBehaviour.SpawnNewEnemy(this.transform);
				trashs--;
				remaingTrash.text = "Lixos restantes: " + trashs;
			}else{
				PlayerPrefs.SetString("roupa",currentTrash);
				PlayerPrefs.SetString("lixo", "plastico");
				gameController.SwitchState(stateMachine.LOSE);
			}
		}

		if(hit.tag == "lixoMetal"){
			if(currentTrash == "metal"){
				Destroy(hit.gameObject);
				spawnBehaviour.SpawnNewEnemy(this.transform);
				trashs--;
				remaingTrash.text = "Lixos restantes: " + trashs;
			}else{
				PlayerPrefs.SetString("roupa",currentTrash);
				PlayerPrefs.SetString("lixo", "metal");
				gameController.SwitchState(stateMachine.LOSE);
			}
		}

		if(hit.tag == "lixoPapel"){
			if(currentTrash == "papel"){
				Destroy(hit.gameObject);
				spawnBehaviour.SpawnNewEnemy(this.transform);
				trashs--;
				remaingTrash.text = "Lixos restantes: " + trashs;
			}else{
				PlayerPrefs.SetString("roupa",currentTrash);
				PlayerPrefs.SetString("lixo", "papel");
				gameController.SwitchState(stateMachine.LOSE);
			}
		}


	}

	private void SetRotation(Transform target){

		Vector3 relativePos = target.position - meshPlayer.position;

		meshPlayer.transform.rotation = Quaternion.LookRotation (relativePos);
		//meshPlayer.transform.LookAt(target);
		//meshPlayer.transform.rotation = new Quaternion(-60f,0,0,90f);

	}

}
