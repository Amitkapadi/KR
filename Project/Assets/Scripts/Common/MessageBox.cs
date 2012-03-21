using UnityEngine;
using System.Collections;

public class MessageBox: MonoBehaviour
{
    private const int OFFSET = 5;
    private string[] cutMessage = new string[0];
    private int curPiece = 0;
    private const float maxHeight = 110f;
    private const float maxWidth = 390f;
    private bool initialized = false;
    private GUIStyle style;
    public static MessageBox instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void OnGUI()
    {
        if (!initialized)
        {
            style = new GUIStyle("label");
            style.wordWrap = true;
            initialized = true;
            enabled = false;
            Messenger.Broadcast("MessageBox Ready");
            return;
        }
        drawMessage();
    }

    void drawMessage()
    {
        Rect boxDimensions = new Rect(Screen.width / 2 - 200,
            Screen.height / 2 - 60, 400, 120);
        Rect textDimensions = new Rect(Screen.width / 2 - 200 + OFFSET,
            Screen.height / 2 - 60 + OFFSET,
            400 - 2 * OFFSET, 120 - 2 * OFFSET);
        GUI.Box(boxDimensions, "");
        
        if (GUI.Button(textDimensions, cutMessage[curPiece], style))
        {
            curPiece++;
            if (curPiece == cutMessage.Length)
            {
                Messenger<bool>.Broadcast("enable movement", true);
                MyCamera.instance.controllingEnabled = true;
                HUD.instance.clickable = true;
                enabled = false;
            }
        }
    }

    public void showMessage(string message)
    {
        cutMessage = Helper.cutPhrase(maxHeight, maxWidth, message, style);
        curPiece = 0;
        Messenger<bool>.Broadcast("enable movement", false);
        MyCamera.instance.controllingEnabled = false;
        HUD.instance.clickable = false;
        enabled = true;
    }
}
