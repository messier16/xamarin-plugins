using M16.StoreInteraction.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using M16.StoreInteraction.Forms.Plugin.Droid;
using Android.Content;

[assembly: Dependency(typeof(StoreInteractionImplementation))]
namespace M16.StoreInteraction.Forms.Plugin.Droid
{
    /// <summary>
    /// StoreInteraction Implementation
    /// </summary>
    public class StoreInteractionImplementation : IStoreInteraction
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        private const string FromPackageName = "market://details?id=";
        private const string FromPublisherName = "market://search?q=pub:";
        private const string FromQuery = "market://search?q=";
        private const string FromQueryEnd = "&c=apps";

		/// <summary>
		/// Opens for publisher.
		/// </summary>
		/// <param name="publisherName">Publisher name.</param>
        public void OpenForPublisher(string publisherName)
        {
            StartIntentForUri(FromPublisherName + publisherName);
        }

		/// <summary>
		/// Opens for app.
		/// </summary>
		/// <param name="appId">App identifier.</param>
        public void OpenForApp(string appId)
        {
            StartIntentForUri(FromPackageName + appId);
        }

		/// <summary>
		/// Opens for query.
		/// </summary>
		/// <param name="searchTerms">Search terms.</param>
		public void OpenForSearch(string searchTerms)
        {
			StartIntentForUri(FromQuery + searchTerms + FromQueryEnd);
        }

		/// <summary>
		/// Starts the intent for URI.
		/// </summary>
		/// <param name="route">Route.</param>
        private void StartIntentForUri(string route)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse(route));
            intent.SetFlags(ActivityFlags.NewTask);
            Xamarin.Forms.Forms.Context.StartActivity(intent);

        }

    }
}
