using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Content.InAppAdvertisement
{
    public class InAppAdvertisementController : MonoBehaviour
    {
        private InAppAdvertisementModel _inAppAdvertisementModel;
        private InAppAdvertisementView _inAppAdvertisementView;
        private MenuView _menuView;

        [Inject]
        private void Construct(InAppAdvertisementModel inAppAdvertisementModel, InAppAdvertisementView inAppAdvertisementView, MenuView menuView)
        {
            _menuView = menuView;
            _inAppAdvertisementView = inAppAdvertisementView;
            _inAppAdvertisementModel = inAppAdvertisementModel;
        }

        private void Start()
        {
            _menuView.Show();
            _menuView.NewInAppAdvertisementRequested += HandleInAppAdvertisementRequest;
            _inAppAdvertisementModel.NewAdAppearedInQueue += HandleAdAppearInQueue;
        }

        private void OnDestroy()
        {
            _menuView.NewInAppAdvertisementRequested -= HandleInAppAdvertisementRequest;
            _inAppAdvertisementModel.NewAdAppearedInQueue -= HandleAdAppearInQueue;
        }

        private void HandleAdAppearInQueue()
        {
            var adData = _inAppAdvertisementModel.GetAdFromQueue();
            _inAppAdvertisementView.Show(adData);
        }

        private void HandleInAppAdvertisementRequest(int amountOfItems)
        {
            _inAppAdvertisementModel.AddNewAd(amountOfItems);
        }
    }
}
