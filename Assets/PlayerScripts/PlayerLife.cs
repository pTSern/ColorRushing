using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource _deathSound;
    [SerializeField] GameObject _endGame;
    // Update is called once per frame
    [SerializeField] MeshRenderer _other;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();    
        }
    }
    bool _die = false;
    public void Die()
    {
        Disable();
        _deathSound.Play();
        Invoke(nameof(Lose), 1.5f);
        this._die = true;
    }

    public void Disable()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        _other.enabled = false;
    }
    
    void Lose()
    {
        var x = _endGame.GetComponent<PopUp>();
        x.SetMessage("YOU LOSE");
        x.Enable();
    }

    public void Win()
    {
        Disable();
        var x = _endGame.GetComponent<PopUp>();
        x.SetMessage("YOU WIN");
        x.Enable();
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus && _die == false) {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
