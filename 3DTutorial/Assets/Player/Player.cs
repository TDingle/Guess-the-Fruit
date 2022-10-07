using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimeData;
    [SerializeField] float _mouseSensitivity = 5f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Camera _cam;
    [SerializeField] TextMeshProUGUI _death;
    [SerializeField] Camera _deathCam;
    float _currentTilt = 0f;
    public static bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
            Movement();
        if (isAlive == false)
        {
            Destroy(gameObject);
            _death.gameObject.SetActive(true);
            _deathCam.gameObject.SetActive(true);
           Application.Quit();
        }

    }
    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");



        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);

    }
    void Movement()
    {
        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + forwardBackwardMovementVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);
    }
}
