using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{

    [Header("MessageBox")]
    public EasyTween Messagetween;
    public EasyTween Texttween;

    public TextMeshProUGUI msgbox;

    public void Message(string msg)
    {
        msgbox.text = msg;
        Messagetween.OpenCloseObjectAnimation();
        Texttween.OpenCloseObjectAnimation();
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2);
        Messagetween.OpenCloseObjectAnimation();
        Texttween.OpenCloseObjectAnimation();
    }

}
