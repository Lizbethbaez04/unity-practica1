using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(filename = "Message", order = 1, menuName = "Advice/warning")]
public class WarningMessage : MonoBehaviour
{
    
    [SerializeField, TextArea(5, 10), Tooltip("Message for advice object"), Header("Configure your message")]
    string message;

    public string Message => message;

    
}
