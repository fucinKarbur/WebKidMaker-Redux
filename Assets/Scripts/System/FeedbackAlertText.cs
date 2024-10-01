using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WKMR.System;

/// <summary>
/// чек где вообще используется этот класс
/// 
/// почему обновление текста в апдейте??
/// 
/// и исправь наконец эту тему с еррор тайп, хоть таблицы прикрути с переводом, 
/// но это супер неудобно, в коде каждлую ошибку прописывать
/// </summary>

namespace WKMR
{
    public class FeedbackAlertText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private string _previousText;

        private ErrorText _alertText = new();

        private void Start()
        {
            _previousText = _text.text;
        }

        private void Update()
        {
            if (_text.text != _previousText)
                ChangeText();
        }

        private void ChangeText()
        {
            Debug.Log("change text");

            switch (_text.text)
            {
                case "Submitting...   ":
                    _text.text = _alertText.GetText(ErrorType.FeedbackSending);
                    break;
                case "Error: Failed to upload report!\n   ":
                    _text.text = _alertText.GetText(ErrorType.FeedbackError);
                    break;
                case "Feedback submitted successfully!   ":
                    _text.text = _alertText.GetText(ErrorType.FeedbackSubmitted);
                    break;
                case "Error: Failed to attach file to report!\n   ":
                    _text.text = _alertText.GetText(ErrorType.FeedbackFileError);
                    break;
                case "Error: Failed to capture screenshot!\nSee log for more detail.   ":
                    _text.text = _alertText.GetText(ErrorType.FeedbackShotError);
                    break;
                default:
                    _text.text = "shit " + Time.captureDeltaTime;
                    break;
            }

            _previousText = _text.text;
        }
    }
}
