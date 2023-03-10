    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _movespeed;
    [SerializeField] private GameObject JoystickPanel;

    private Animator _animator;
    private Rigidbody _rigidbody;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        JoystickPanel.SetActive(true);
    }

    private void FixedUpdate()
    {
       
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _movespeed, _rigidbody.velocity.y, _joystick.Vertical * _movespeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetFloat("run", 1f);
            gameManager.isPlayerRunning = true;
        }
        else
        {
            gameManager.isPlayerRunning = false;
            _animator.SetFloat("run", 0f);


        }
    }
    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "char")
        {

            col.GetComponent<ActiveHuman>().JoinToCharacters();
        }
    }*/

}
