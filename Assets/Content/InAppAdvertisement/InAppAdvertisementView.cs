using System;
using System.Collections.Generic;
using Content.Common;
using Content.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Content.InAppAdvertisement
{
    public class InAppAdvertisementView : MonoBehaviour
    {
        [SerializeField] private Image _bigIconImage;
        [SerializeField] private TMP_Text _labelText, _descriptionText, _priceText, _originalPriceText, _discountText;
        [SerializeField] private Transform _itemLayout;
        [SerializeField] private Button _closeButton;
        private IProvider<ItemView> _itemViewProvider;
        private INamedProvider<Sprite> _spriteProvider;
        private List<ItemView> _itemViews = new List<ItemView>();
        

        [Inject]
        private void Construct(IProvider<ItemView> itemViewProvider, INamedProvider<Sprite> spriteProvider)
        {
            _spriteProvider = spriteProvider;
            _itemViewProvider = itemViewProvider;
        }

        private void Start()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        public void Show(InAppAdvertisementDisplayData displayData)
        {
            gameObject.SetActive(true);

            _bigIconImage.sprite = _spriteProvider.Get(displayData.BigIconName);
            _labelText.text = displayData.Label;
            _descriptionText.text = displayData.Description;
            _priceText.text = $"${displayData.Price * displayData.DiscountPotion01:0.00}";
            _originalPriceText.gameObject.SetActive(displayData.DiscountPotion01 > 0);
            _originalPriceText.text = $"$<s><color=#CCC>{displayData.Price:0.00}";
            _discountText.text = $"-{displayData.DiscountPotion01 * 100:0}%";

            for (var i = 0; i < displayData.Items.Length; i++)
            {
                ItemView itemView;
                if (i >= _itemViews.Count)
                {
                    itemView = _itemViewProvider.Get();
                    itemView.transform.SetParent(_itemLayout, false);
                    _itemViews.Add(itemView);
                }
                else
                {
                    itemView = _itemViews[i];
                }
                var itemData = displayData.Items[i];
                itemView.SetData(_spriteProvider.Get(itemData.ItemIconName), itemData.Amount);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
