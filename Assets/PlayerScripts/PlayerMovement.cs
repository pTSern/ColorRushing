using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Stats stats;
    private Rigidbody body;
    private Vector3 safePoint;
    [SerializeField] Text _speedText;
    [SerializeField] float _maxSpeed = 50;

    [SerializeField] private Transform camTransform;
    public Animator animator;

    void Start()
    {
        stats = GetComponent<Stats>();
        body = GetComponent<Rigidbody>();
    }

    void UpdateText()
    {
        _speedText.text = "Speed: " + (stats.getSpeed() * spd_scaler);
    }

    float spd_scaler = 1.0f;
    float energy = 500;

    bool _on_spd_up = false;

    public float vert { set; private get; }
    public float hort { set; private get; }
    
    void Update()
    {
        vert = Input.GetAxis("Vertical") * stats.getSpeed();
        hort = Input.GetAxis("Horizontal") * stats.getSpeed();

        Vector3 moveDir = new Vector3(hort, 0, vert);
        float inputMag = Mathf.Clamp01(moveDir.magnitude);

        float spd = inputMag * stats.getSpeed();
        moveDir = Quaternion.AngleAxis(camTransform.rotation.eulerAngles.y, Vector3.up) * moveDir;
        moveDir.Normalize();

        Vector3 vel = moveDir * spd * spd_scaler;
        vel.y = Input.GetButtonDown("Jump") ? stats.getJumpForce() : body.velocity.y;

        if(Input.GetKeyDown(KeyCode.LeftShift) && !_on_spd_up) {
            spd_scaler = 2;
            _on_spd_up = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && _on_spd_up) {
            _on_spd_up = false;
            spd_scaler = 1;
        }

        if(_on_spd_up) {
            energy -= 1;
            if(energy <= 0) {
                _on_spd_up = false;
                spd_scaler = 1;
            }
        }
        else {
            energy += 1;
            if(energy >= 500) energy = 500;
        }

        body.velocity = vel;
        safePoint = transform.position;
        if(moveDir != Vector3.zero) {
            this.animator.SetTrigger("Walking");
            this.animator.ResetTrigger("Idle");
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        } else {
            this.animator.SetTrigger("Idle");
            this.animator.ResetTrigger("Walking");
        }
        UpdateText();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //body.velocity = Vector3.zero;
            //body.angularVelocity = Vector3.zero;
            transform.position = safePoint;
        }
    }

    public void BoostSpeed(float amount)
    {
        if(stats.getSpeed() < _maxSpeed)
        {
            stats.AddSpeed(amount);
        }
    }



}
