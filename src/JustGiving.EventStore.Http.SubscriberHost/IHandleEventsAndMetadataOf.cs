using System;
using System.Threading.Tasks;
using JustGiving.EventStore.Http.Client;

namespace JustGiving.EventStore.Http.SubscriberHost
{
    /// <summary>
    /// A handler for events coming from the <see cref="EventStoreHttpConnection"/>
    /// </summary>
    /// <typeparam name="T">The type of event this handler handles</typeparam>
    public interface IHandleEventsAndMetadataOf<in T>
    {
        /// <summary>
        /// Runs the main event-processing logic for an event.  
        /// </summary>
        /// <param name="event">The event to be processed</param>
        /// <param name="metadata">The EventStore metadata</param>
        /// <returns>A <see cref="Task"/> to be awaited. The task must not be null</returns>
        Task Handle(T @event, BasicEventInfo metadata);

        /// <summary>
        /// An error handler to be run in case the Handle method throws an exception
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> thrown by the Handle method</param>
        /// <param name="event">The event that was being handled when the exception occured</param>
        /// <remarks>This method should not throw an exception</remarks>
        void OnError(Exception ex, T @event);
    }
}