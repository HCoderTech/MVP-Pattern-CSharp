using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test_MVP.EventAggregator
{
    public interface IEventAggregator
    {
        void PublishEvent<TEventType>(TEventType eventToPublish);

        void SubsribeEvent(Object subscriber);
    }

    public interface ISubscriber<TEventType>
    {
        void OnEventHandler(TEventType e);
    }
    class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, List<WeakReference>> eventSubscribers = new Dictionary<Type, List<WeakReference>>();

        private readonly object lockSubscriberDictionary = new object();

        public void PublishEvent<TEventType>(TEventType eventToPublish)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventType));

            var subscribers = GetSubscriberList(subscriberType);

            List<WeakReference> subscribersToBeRemoved = new List<WeakReference>();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscriber<TEventType>)weakSubscriber.Target;

                    InvokeSubscriberEvent<TEventType>(eventToPublish, subscriber);
                }
                else
                {
                    subscribersToBeRemoved.Add(weakSubscriber);

                }//End-if-else (weakSubsriber.IsAlive)

            }//End-for-each (var weakSubriber in subscribers)


            if (subscribersToBeRemoved.Any())
            {
                lock (lockSubscriberDictionary)
                {
                    foreach (var remove in subscribersToBeRemoved)
                    {
                        subscribers.Remove(remove);

                    }//End-for-each (var remove in subsribersToBeRemoved)

                }//End-lock (lockSubscriberDictionary)

            }//End-if (subsribersToBeRemoved.Any())
        }

        public void SubsribeEvent(object subscriber)
        {
            lock (lockSubscriberDictionary)
            {
                var subscriberTypes = subscriber.GetType().GetInterfaces()
                                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                WeakReference weakReference = new WeakReference(subscriber);

                foreach (var subsriberType in subscriberTypes)
                {
                    List<WeakReference> subscribers = GetSubscriberList(subsriberType);

                    subscribers.Add(weakReference);

                }//End-for-each (var subsriberType in subsriberTypes)

            }//End-lock (lockSubscriberDictionary)
        }

        private void InvokeSubscriberEvent<TEventType>(TEventType eventToPublish, ISubscriber<TEventType> subscriber)
        {
            //Synchronize the invocation of method 

            SynchronizationContext syncContext = SynchronizationContext.Current;

            if (syncContext == null)
            {
                syncContext = new SynchronizationContext();

            }//End-if (syncContext == null)
            System.IO.File.AppendAllText(@"D:\text.txt", "Invoking " + eventToPublish.ToString() +"'s EventHandler on "+ subscriber.ToString()+ Environment.NewLine);
            
            syncContext.Send(s => subscriber.OnEventHandler(eventToPublish), null);
            

        }

        private List<WeakReference> GetSubscriberList(Type subsriberType)
        {
            List<WeakReference> subscribersList = null;

            lock (lockSubscriberDictionary)
            {
                bool found = this.eventSubscribers.TryGetValue(subsriberType, out subscribersList);

                if (!found)
                {
                    //First time create the list.

                    subscribersList = new List<WeakReference>();

                    this.eventSubscribers.Add(subsriberType, subscribersList);

                }//End-if (!found)

            }//End-lock (lockSubscriberDictionary)

            return subscribersList;
        }

    }
}
