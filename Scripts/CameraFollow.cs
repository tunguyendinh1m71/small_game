// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class CameraFollow : MonoBehaviour
// {
//     public const string MouseXString = "Mouse X";
//     public const string MouseYString = "Mouse Y";
//     public const string MouseScrollString = "Mouse ScrollWheel";

//     public static float MouseXInput {get => UnityEngine.Input.GetAxis(MouseXString);}
//     public static float MouseYInput {get => UnityEngine.Input.GetAxis(MouseYString);}
//     public static float MouseScrollInput {get => UnityEngine.Input.GetAxis(MouseScrollString);}
    
//     [Header("Rotation")]
//     [SerializeField] private bool _invertX = false;
//     [SerializeField] private bool _invertY = false;
//     [SerializeField] private float _defaultVerticalAngle = 20f;
//     [SerializeField] private float _rotationSharpness = 25f;
//     [SerializeField] [Range(-90,90)] private float _minVerticalAngle = -90;
//     [SerializeField] [Range(-90,90)] private float _maxVerticalAngle = 90;
//     [SerializeField] private Vector2 _framing = new Vector3(0, 0, 0);

//     // [Header("LockOn")]
//     // // [SerializeField] private float _lockOnDistance = 15;
//     // // [SerializeField] private LayerMask _lockOnLayers = -1;
//     // [SerializeField] private bool _lockedOn;
//     // private Transform _target;

//     [Header("Distance")]
//     [SerializeField] private float _zoomSpeed = 10f;
//     [SerializeField] private float _defaultDistance = 5f;
//     [SerializeField] private float _minDistance = 0f;
//     [SerializeField] private float _maxDistance = 10f;

//     [Header("Obstruction")]
//     [SerializeField] private float _checkRadius = 0.2f;
//     [SerializeField] private LayerMask _obstructionLayer = -1;
//     private List<Collider> _ignoreCollider = new List<Collider>();
    
//     // [Header("NoticeZone")]
//     // [SerializeField] float _noticeZone = 10;
//     // [SerializeField] float _maxNoticeAngle = 60;
//     // [SerializeField] private LayerMask _targetLayers = -1;
//     // [SerializeField] bool zeroVert_Look;



//     [Header("Framing")]
//     [SerializeField]private Camera _camera = null;
//     [SerializeField]private Transform _followTransform = null;



//     //float _currentYOffset;
//     // public bool LockedOn {get => _lockedOn; }
//     // public Transform Target {get => _target; } 
//     public Vector3 CameraPlanarDirection {get => _planarDirection;} 
//     private Vector3 _planarDirection; //Camere forward on x,z plane
//     private Quaternion _targetRotation;
//     private Vector3 _targetPosition;
//     private float _targetDistance;
//     private float _targetverticalAngle;
//     private Vector3 _newPostion;
//     private Quaternion _newRotation;

//     private void OnValidate() {
//         _defaultDistance = Mathf.Clamp(_defaultDistance, _minDistance, _maxDistance);
//         _defaultVerticalAngle = Mathf.Clamp(_defaultVerticalAngle, _minVerticalAngle, _maxVerticalAngle);
//     }
//     private void Start() {

//         _ignoreCollider.AddRange(GetComponentsInChildren<Collider>());
//         //important
//         _planarDirection = _followTransform.forward;
        
//         Cursor.lockState = CursorLockMode.Locked;

//         //Caculate Targets
//         _targetDistance = _defaultDistance;
//         _targetverticalAngle = _defaultVerticalAngle;
//         _targetRotation = Quaternion.LookRotation(_planarDirection) * Quaternion.Euler(_targetverticalAngle, 0, 0);
//         _targetPosition = _followTransform.position - (_targetRotation * Vector3.forward) * _targetDistance;
//     }
//     private void Update() {
        
//         if(Cursor.lockState != CursorLockMode.Locked)
//             return;
        
//         //handle input
//         float _zoom = MouseScrollInput * _zoomSpeed;
//         float _mouseX = MouseXInput;
//         float _mouseY = MouseYInput;

//         if(_invertX) {_mouseX *= -1f;}
//         if(_invertY) {_mouseY *= -1f;}

//         Vector3 _focusPosition = _followTransform.position + _camera.transform.TransformDirection(_framing); 
//         // if (_lockedOn && _target != null){

//         //     Vector3 _camToTarget = _target.position - _camera.transform.position;
//         //     Vector3 _planarCamToTarget = Vector3.ProjectOnPlane(_camToTarget, Vector3.up);
//         //     Quaternion _lookRotation = Quaternion.LookRotation(_camToTarget, Vector3.up);


//         //     _planarDirection = _planarCamToTarget != Vector3.zero ? _planarCamToTarget : _planarDirection;
//         //     _targetDistance = Mathf.Clamp(_targetDistance + _zoom, _minDistance, _maxDistance);
//         //     _targetverticalAngle = Mathf.Clamp(_targetverticalAngle + _mouseX, 10, 10);   
//         // }
//         // else{
//         _planarDirection = Quaternion.Euler(0, _mouseX, 0) * _planarDirection;
//         _targetverticalAngle = Mathf.Clamp(_targetverticalAngle + _mouseY,_minVerticalAngle, _maxVerticalAngle);
//         _targetDistance = Mathf.Clamp(_targetDistance + _zoom, _minDistance, _maxDistance);
//         //}

//         Debug.DrawLine(_camera.transform.position, _camera.transform.position + _planarDirection, Color.red);
        
//         //Handle obstructions (affect target distance)
//         float _smallestDistance = _targetDistance;
//         RaycastHit[] _hits = Physics.SphereCastAll( _focusPosition, _checkRadius, _targetRotation * -Vector3.forward, _targetDistance, _obstructionLayer);
//         if(_hits.Length != 0)
//             foreach(RaycastHit hit in _hits)
//                 if(!_ignoreCollider.Contains(hit.collider))
//                     if(hit.distance < _smallestDistance)
//                         _smallestDistance = hit.distance;
        

//         //final target
//         _targetRotation = Quaternion.LookRotation(_planarDirection) * Quaternion.Euler(_targetverticalAngle, 0, 0);
//         _targetPosition = _focusPosition - (_targetRotation * Vector3.forward) * _smallestDistance;

//         //handle smoothing
//         _newPostion = Vector3.Slerp(_camera.transform.position, _targetPosition, Time.deltaTime * _rotationSharpness);
//         _newRotation = Quaternion.Slerp(_camera.transform.rotation, _targetRotation, Time.deltaTime * _rotationSharpness);

//         //apply
//         _camera.transform.rotation = _newRotation; 
//         _camera.transform.position = _newPostion;
//     }

//     // public void ToggleLock(bool toggle){
//     //     //Early out
//     //     if (toggle == _lockedOn){
//     //         return;
//     //     }

//     //     //toggle
//     //     _lockedOn = !_lockedOn;
//     // }
    


//     // void LateUpdate (){
//     //     Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _targetPosition, Time.deltaTime * 1000);
    
//     // }
// }


//     //     if(_lockedOn){
//     //         //filters targetables
//     //         List<Itangible> _targetables = new List<Itangible>();
//     //         Collider[] _colliders = Physics.OverlapSphere(transform.position, _lockOnDistance, _lockOnLayers);
//     //         foreach(Collider _collider in _colliders){
//     //             Itangible _targetable = _collider.GetComponent<Itangible>();
//     //             if(_targetable != null){
//     //                 if(_targetable.Targetable){
//     //                     if(InScreen(_targetable)){
//     //                         if(NotBlocked(_targetable)){
//     //                             _targetables.Add(_targetable);
//     //                         }
//     //                     }
//     //                 }
//     //             } 
//     //         }
//     //         //Find closest targetable to screen center
//     //         float _hypotenuse;
//     //         float _smallesthypotenuse = Mathf.Infinity;
//     //         Transform _closestTargetable = null;
//     //         foreach(Itangible _targetable in _targetables){
//     //             _hypotenuse = CaculateHypotenuse(_targetable.TargetTransform.position);
//     //             if(_smallesthypotenuse> _hypotenuse){
//     //                 _closestTargetable = _targetable;
//     //                 _smallesthypotenuse = _hypotenuse;
//     //             }

//     //         }
//     //         //final
//     //         _target = _closestTargetable;
//     //         _lockedOn = _closestTargetable != null;
//     //     }
//     // }
    
//     // private bool InDistance(){
//     //     float _distance = Vector3.Distance(transform.position, Target.position);
//     //     return _distance <= _lockOnDistance;
//     // }

//     // private bool InScreen(){
//     //     Vector3 _viewPortPosition = _camera.WorldToViewportPoint(Target.position);

//     //     if(!(_viewPortPosition.x > 0) || !(_viewPortPosition.x < 1)) {return false;}
//     //     if(!(_viewPortPosition.y > 0) || !(_viewPortPosition.y < 1)) {return false;}
//     //     if(!(_viewPortPosition.z > 0))                               {return false;}

//     //     return true;     
//     // }

//     // private bool NotBlocked(){

//     //     Vector3 _origin = _camera.transform.position;
//     //     Vector3 _direction = Target.position - _origin;

//     //     float _radius = 0.15f;
//     //     float _distance = _direction.magnitude;
//     //     bool _notBlocked = !Physics.SphereCast(_origin, _radius, _direction, out RaycastHit _hit, _distance, _obstructionLayer);

//     //     return _notBlocked;
        

//     // }
//     // private float CaculateHypotenuse(Vector3 position){
//     //     float _screenCenterX = _camera.pixelWidth / 2;
//     //     float _screenCenterY = _camera.pixelHeight / 2;

//     //     Vector3 _screenPositon = _camera.WorldToScreenPoint(position);
//     //     float _xDelta = _screenCenterX - _screenPositon.x;
//     //     float _yDelta = _screenCenterY - _screenPositon.y;
//     //     float _hypotenuse = Mathf.Sqrt(Mathf.Pow(_xDelta, 2) + Mathf.Pow(_yDelta, 2));

//     //     return _hypotenuse;
//     // }


