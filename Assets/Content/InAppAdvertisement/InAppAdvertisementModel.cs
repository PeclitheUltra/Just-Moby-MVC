using System;
using System.Collections.Generic;

namespace Content.InAppAdvertisement
{
    public class InAppAdvertisementModel
    {
        public event Action NewAdAppearedInQueue;
        private Queue<InAppAdvertisementDisplayData> _pendingAds = new Queue<InAppAdvertisementDisplayData>();
        
        public void AddNewAd(int itemAmount)
        {
            AddNewAd(new InAppAdvertisementDisplayData(itemAmount));
        }

        public void AddNewAd(InAppAdvertisementDisplayData data)
        {
            _pendingAds.Enqueue(data);
            NewAdAppearedInQueue?.Invoke();
        }

        public InAppAdvertisementDisplayData GetAdFromQueue()
        {
            return _pendingAds.Dequeue();
        }
    }
}