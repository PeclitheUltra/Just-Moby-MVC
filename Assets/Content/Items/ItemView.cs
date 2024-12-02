using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _amountText;

        public void SetData(Sprite icon, int amount)
        {
            _iconImage.sprite = icon;
            _amountText.text = amount.ToString();
        }
    }
}