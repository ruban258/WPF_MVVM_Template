using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubscriptionAttribute: Attribute
    {
        //
        // Summary:
        //     Gets the endpoint url.
        public string EndpointUrl { get; }

        //
        // Summary:
        //     Gets the publishing interval.
        public double PublishingInterval { get; }

        //
        // Summary:
        //     Gets the number of PublishingIntervals before the server should return an empty
        //     Publish response.
        public uint KeepAliveCount { get; }

        //
        // Summary:
        //     Gets the number of PublishingIntervals before the server should delete the subscription.
        public uint LifetimeCount { get; }

        //
        // Summary:
        //     Gets a value indicating whether publishing is enabled.
        public bool PublishingEnabled { get; }

        //
        // Summary:
        //     Initializes a new instance of the Workstation.ServiceModel.Ua.SubscriptionAttribute
        //     class.
        //
        // Parameters:
        //   endpointUrl:
        //     the endpoint url.
        //
        //   publishingInterval:
        //     the publishing interval.
        //
        //   keepAliveCount:
        //     the number of PublishingIntervals before the server should return an empty Publish
        //     response.
        //
        //   lifetimeCount:
        //     the number of PublishingIntervals before the server should delete the subscription.
        //
        //
        //   publishingEnabled:
        //     whether publishing is enabled.
        public SubscriptionAttribute(string endpointUrl, double publishingInterval = 1000.0, uint keepAliveCount = 10u, uint lifetimeCount = 0u, bool publishingEnabled = true)
        {
            EndpointUrl = endpointUrl;
            PublishingInterval = publishingInterval;
            KeepAliveCount = keepAliveCount;
            LifetimeCount = lifetimeCount;
            PublishingEnabled = publishingEnabled;
        }
    }
}
