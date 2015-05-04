var target : GameObject;
var distance = 15.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;

private var currentFocus;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
	Time.timeScale = 0.75f;
	currentFocus = target.transform.name;
	
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}
function Update(){

	//SWITCH PLANET VIEW
	if(Input.GetKeyDown(KeyCode.RightArrow)){
		
		var temp = int.Parse(target.transform.name)+1;
	
		if(temp == 5){
			temp = 1;
		}
		target = GameObject.Find(temp.ToString());
		currentFocus = target.transform.name;
		distance = target.transform.localScale.y*2f;
	}
	if(Input.GetKeyDown(KeyCode.LeftArrow)){
		var tmp = int.Parse(target.transform.name)-1;
	
		if(tmp == 0){
			tmp = 4;
		}
		target = GameObject.Find(tmp.ToString());
		currentFocus = target.transform.name;
		distance = target.transform.localScale.y*2f;
	}
	
	//MOUSE SCROLL LOGIC (PLANET VS SPACE STATION)
	if(target.transform.name != "SS"){
		if(Input.GetAxis("Mouse ScrollWheel")<0&&distance<(target.transform.localScale.y+30f)){
			distance += 0.3;
		}
		if(Input.GetAxis("Mouse ScrollWheel")>0&&distance>(target.transform.localScale.y+0.5f)){
			distance -= 0.3;
		}
	}else{
		if(Input.GetAxis("Mouse ScrollWheel")<0&&distance<(target.transform.localScale.y+5f)){
			distance += 0.2;
		}
		if(Input.GetAxis("Mouse ScrollWheel")>0&&distance>(target.transform.localScale.y+1f)){
			distance -= 0.2;
		}
	}
	
	//ZOOM IN/OUT SPACE STATION
	if(Input.GetKeyDown(KeyCode.UpArrow )){
		
		target = GameObject.Find("SS");
		distance = 1.5f;
	}
	if(Input.GetKeyDown(KeyCode.DownArrow)) {
		target = GameObject.Find(currentFocus);
		distance = target.transform.localScale.y*2f;
	}
	
	//MODIFY TIME SCALE (FAST FORWARD)
	if(Input.GetKeyDown(KeyCode.Alpha0)) Time.timeScale = 0f;
	if(Input.GetKeyDown(KeyCode.Alpha1)) Time.timeScale = 0.75f;
	if(Input.GetKeyDown(KeyCode.Alpha2)) Time.timeScale = 2f;
	if(Input.GetKeyDown(KeyCode.Alpha3)) Time.timeScale = 5f;
	if(Input.GetKeyDown(KeyCode.Alpha4)) Time.timeScale = 10f;

}
function LateUpdate () {
	
    if (target) {
    	if(Input.GetMouseButton(0)){
      	  	x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        	y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 			y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       }
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.transform.position;
        
        transform.rotation = rotation;
        transform.position = position;
        
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}