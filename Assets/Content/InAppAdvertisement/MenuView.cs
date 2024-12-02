using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.InAppAdvertisement
{
    public class MenuView : MonoBehaviour
    {
        public event Action<int> NewInAppAdvertisementRequested;
        
        [SerializeField] private TMP_Text _input;
        [SerializeField] private Button _confirmButton;

        private void Start()
        {
            _confirmButton.onClick.AddListener(HandleConfirmClick);
        }

        private void HandleConfirmClick()
        {
            string inputString = Regex.Match(_input.text, @"\d+").Value;
            if (int.TryParse(inputString, out var parseResult))
            {
                if (parseResult >= 3 && parseResult <= 6)
                {
                    NewInAppAdvertisementRequested?.Invoke(parseResult);
                    return;
                }
            }
            Debug.LogError($"Wrong input, awaiting integer between 3 and 6 inclusively, received {parseResult}");

        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
