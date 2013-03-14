private var motor : CharacterMotor;
private var controller : CharacterController;
private var canCrouch;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	controller = GetComponent(CharacterController);
	
	canCrouch = true;
}

// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	var sprint = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
	
	/*
	if(Input.GetKeyUp(KeyCode.LeftControl)) {
		if(controller.isGrounded) {
			if(!Physics.Raycast(transform.position, Vector3.up, 2)) {
				controller.height = 2;
				var hit : RaycastHit;
				if(Physics.Raycast(transform.position, Vector3.down, hit, 2)) {
					if(hit.transform.tag == "") {
						var y = hit.transform.position.y + 1;
						transform.position = new Vector3(transform.position.x, y, transform.position.z);
					}else controller.Move(Vector3.up);
				}
			}
		}else controller.height = 2;
	}else if(Input.GetKeyDown(KeyCode.LeftControl)) {
		if(canCrouch) {
			controller.height = 0.5;
			
			canCrouch = false;
			StartCoroutine("crouchCooldown");
		}
	}*/
	
	if(Input.GetKeyUp(KeyCode.LeftControl)) { //Stand
		if(!Physics.Raycast(transform.position, Vector3.up, 2)) {
			transform.localScale = new Vector3(1, 1, 1);
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.5, transform.position.z);
		}
	}else if(Input.GetKeyDown(KeyCode.LeftControl)) { //Crouch
		if(canCrouch) {
			transform.localScale = new Vector3(1, 0.5, 1);
			
			canCrouch = false;
			StartCoroutine("crouchCooldown");
		}
	}
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector * sprint;
	motor.inputJump = Input.GetButton("Jump");
}

function crouchCooldown() {
	yield WaitForSeconds(0.5);
	canCrouch = true;
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
