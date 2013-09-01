using Assets.net.kibotu.sandbox.unity.dragnslay.model;
using Assets.net.kibotu.sandbox.unity.dragnslay.network;
using Assets.net.kibotu.sandbox.unity.dragnslay.scripts;
using UnityEngine;

namespace Assets.net.kibotu.sandbox.unity.dragnslay.game
{
    public class Game1vs1 : MonoBehaviour {
	
        public Texture btnTexture;
        private bool buttonIsVisible = true;
	
        void OnGUI() {
            if (!btnTexture) {
                Debug.LogError("Please assign a texture on the inspector");
                return;
            }
            if (buttonIsVisible && GUI.Button(new Rect(10, 10, 400, 220), btnTexture)) {
                buttonIsVisible = false;
                startGame();
            }
        }
	
        void startGame() {

            ClientSocket.Instance.Connect("http://127.0.0.1:3000/");

            Orb a = createOrb(new Vector3(0,2,0));
            //Orb b = createOrb(new Vector3(5,0,0));

            ClientSocket.Instance.On("message", (data) =>
                { if (data != null) Debug.Log("received message : " + data); });

		
            //Planet [] p = new Planet[10] { n	ew Planet() };
            // add planets to stage
		
            // spawn ships
		
            // touch events
        }
	
        public bool isDragging = false;
	
        public void OnMouseDown () {
            Debug.Log("OnMouseDown");
        }
	
        public void OnMouseDrag () {
	
            Debug.Log("OnMouseDrag");
		
            if (!isDragging) {
                //Do something here
                isDragging = true;
            }
        }
	
        public void OnMouseUp () {
            Debug.Log("OnMouseUp");
            isDragging = false;

        }
	
        void Start () {
            /*Particle[] particles = particleEmitter.particles;
	    int i = 0;
	    while (i < particles.Length) {
	        float yPosition = Mathf.Sin(Time.time) * Time.deltaTime;
	        particles[i].position += new Vector3(0, yPosition, 0);
	        particles[i].color = Color.red;
	        particles[i].size = Mathf.Sin(Time.time) * 0.2F;
	        i++;
	    }
	    particleEmitter.particles = particles;
		
	  	originalColor = renderer.sharedMaterial.color;*/
        }
	
        void Update () {
		
            if(Input.GetMouseButtonDown(0))  {
                Vector3 screenPos = Input.mousePosition;
                screenPos.z = 30;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                Debug.Log(screenPos + " " + worldPos);
            }
		
            if(isDragging) Debug.Log("is dragging");
		
		
            /*foreach (Touch touch in Input.touches) {
			Debug.Log(touch.position);
			if (touch.phase == TouchPhase.Began) {
					// Construct a ray from the current touch coordinates
				var ray = Camera.main.ScreenPointToRay (touch.position);
				if (Physics.Raycast (ray)) {
					// Create a particle if hit
					Instantiate (particle, transform.position, transform.rotation);
					Debug.Log(touch.position);
				}
				Debug.Log(touch.position);
			}
		}*/
        }
	
        public static Orb createOrb(Vector3 position) {
            Orb orb = new Orb();
            orb.currentPopulation = 0;
            orb.maxPopulation = 10;
            orb.textureId = 0;
            orb.spawnPerSec = 0.5f;
            orb.life = new Life();
            orb.life.current_hp = orb.life.max_hp = 100;
            orb.life.armor = orb.life.current_shield = orb.life.max_shield = 0;
            orb.life.shield_regen = orb.life.hp_regen = 0f;
            orb.physicalProperty = new PhysicalProperty();
            orb.physicalProperty.acceleration = 0f;
		
            orb.physicalProperty.position = position;
            orb.physicalProperty.scalling = new Vector3(1,1,1);
            orb.physicalProperty.rotation = new Quaternion(0,0,0,0);
		
            orb.physicalProperty.mass = 0f;
            orb.physicalProperty.rotationSpeed = 23f;
            orb.physicalProperty.rotationDistance = 0f;
		
            orb.type = new TrabantPrototype();
            orb.type.physicalProperty = new PhysicalProperty();
            orb.type.physicalProperty.rotationDistance = 0f;
            orb.type.physicalProperty.position = new Vector3(1.5f,0,0);

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            orb.go = go;
            go.renderer.material.mainTexture = Resources.Load("glass") as Texture;
            go.transform.position = orb.physicalProperty.position;
		
            go.AddComponent<Orbitting>();
            go.AddComponent<SendUnits>();
		
            //GameObject cube = new GameObject("spaseship");
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		
            cube.transform.position = orb.type.physicalProperty.position;
            cube.transform.parent = go.transform;
		
            return orb;
        }
    }
}