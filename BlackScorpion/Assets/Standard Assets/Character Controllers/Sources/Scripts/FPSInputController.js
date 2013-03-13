private var motor : CharacterMotor;
private var controller : CharacterController;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	controller = GetComponent(CharacterController);
}

// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	var sprint = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
	
	if(Input.GetKeyDown(KeyCode.LeftControl)) controller.height = 0.5;
	else if(Input.GetKeyUp(KeyCode.LeftControl)) {
		if(controller.isGrounded) {
			if(!Physics.Raycast(transform.position, Vector3.up, 2)) {
				controller.height = 2;
				var hit : RaycastHit;
				if(Physics.Raycast(transform.position, Vector3.down, hit, 2)) {
					var y = hit.transform.position.y + 1;
					Debug.Log("Zip: " + y);
					transform.position = new Vector3(transform.position.x, y, transform.position.z);
					
				}
			}else Debug.Log("Block above");
		}else controller.height = 2;
	}
	
	Debug.Log(GetComponent(CharacterController).height);
	
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

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
