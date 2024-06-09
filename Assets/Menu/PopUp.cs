using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Text _endGameMessage;
    //GameObject _target;
    [SerializeField] GameObject _target;

    void Start()
    {
        Disable();
        //_target = gameObject;
    }

    public void Disable()
    {
        _target.SetActive(false);
        
    }
    public void Enable()
    {
        _target.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void SetMessage(string message)
    {
        _endGameMessage.text = message;
    }

}
