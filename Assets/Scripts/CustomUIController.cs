using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;
using UniOSC;
using UnityEngine.Assertions;

public class CustomUIController : MonoBehaviour
{
    // limits how often a button can be selected while colliding with it
    private bool limitSelection = false;

    public Transform piano;

    [SerializeField]
    private float scale;

    // used to disable ui elements
    public GameObject[] uiObjects;
    private bool isActive = true;
    private bool hasActivated = false;

    [SerializeField]
    private CustomAudioManager _audioManger = null;

    private void Awake()
    {
        Assert.IsNotNull(_audioManger);
    }

    // references to text and UniOSC classes
    #region
    public Text ipAddress;

    [SerializeField]
    private UniOSCConnection ipConnection;

    [SerializeField]
    private UniOSCEventDispatcherButton dispatcher;

    private string fillerText = "";

    // for testing
    public InputField textField;
    #endregion

    private void Update()
    {
        // for testing
        if (Input.GetKeyDown(KeyCode.A))
        {
            piano.localScale *= scale;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            piano.localScale /= scale;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ipConnection.oscOutIPAddress = textField.text;
            ipConnection.ConnectOSCOut();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            dispatcher.SendOSCMessageDown();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            foreach (GameObject objs in uiObjects)
            {
                isActive = false;
                objs.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isActive == false)
        {
            foreach (GameObject objs in uiObjects)
            {
                isActive = true;
                objs.SetActive(true);
            }
        }
    }
    // Numpad object methods
    #region

    // will make sure to concatenate string as more are selected
    private void ChangeText(string newString)
    {
        if (ipAddress.text == "Enter IP Address" || ipAddress.text == fillerText)
        {
            ipAddress.text = newString;
        }
        else
        {
            ipAddress.text += newString;
        }
    }

    private void RemoveLastDigit()
    {
        {
            ipAddress.text = fillerText;
        }
    }

    // Update IP string with digit 7
    public void Add7String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                ChangeText("7");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add8String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("8");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add9String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("9");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add4String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("4");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add5String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("5");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add6String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("6");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add1String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("1");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add2String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("2");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add3String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("3");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void AddPeriodString(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText(".");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }
    public void Add0String(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            limitSelection = true;

            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                // update address
                ChangeText("0");
                _audioManger.PlayUIClick();
            }
            // play coroutine to reset bool
            StartCoroutine(ResetBool());
        }
    }

    public void ClearText(InteractableStateArgs obj)
    {
        if (obj.NewInteractableState == InteractableState.ActionState)
        {
            // update address
            RemoveLastDigit();
            _audioManger.PlayUIClick();
        }
    }

    // Update IP Address to accurately reflect phone address
    public void EnterIPAddress(InteractableStateArgs obj)
    {
        if (obj.NewInteractableState == InteractableState.ActionState)
        {
            // update address
            ipConnection.oscOutIPAddress = ipAddress.text;
            ipConnection.ConnectOSCOut();
            _audioManger.PlayUIClick();
        }
    }

    #endregion

    // for scaling piano scale
    #region
    public void IncreasePianoScale(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                piano.localScale *= scale;
                _audioManger.PlayUIClick();

                // play coroutine to reset bool
                StartCoroutine(ResetBool());
            }
        }
    }

    public void DecreasePianoScale(InteractableStateArgs obj)
    {
        if (limitSelection == false)
        {
            if (obj.NewInteractableState == InteractableState.ActionState)
            {
                piano.localScale /= scale;
                _audioManger.PlayUIClick();

                // play coroutine to reset bool
                StartCoroutine(ResetBool());
            }
        }
    }
    #endregion

    // for enabling/diabling ui
    #region
    public void EnableDisableUI(InteractableStateArgs obj)
    {
        if (obj.NewInteractableState == InteractableState.ActionState)
        {
            if (isActive == true)
            {
                foreach (GameObject objs in uiObjects)
                {
                    isActive = false;
                    objs.SetActive(false);
                    _audioManger.PlayUIClick();
                }
            }
            else if (obj.NewInteractableState == InteractableState.ActionState)
            {
                if (isActive == false)
                {
                    foreach (GameObject objs in uiObjects)
                    {
                        isActive = true;
                        objs.SetActive(true);
                        _audioManger.PlayUIClick();
                    }
                }
            }
        }
    }
    #endregion

    private IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(1);
        limitSelection = false;
    }
}
