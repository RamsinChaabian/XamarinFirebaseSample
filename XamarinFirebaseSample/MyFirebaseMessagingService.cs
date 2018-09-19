using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Support.V4.App;
using Firebase.Messaging;

namespace XamarinFirebaseSample
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]

    class MyFirebaseMessagingService : FirebaseMessagingService
    {

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            SendNotification(message.GetNotification().Body);
        }

        private void SendNotification(string body)
        {
            string appName = PackageManager.GetApplicationLabel(PackageManager.GetApplicationInfo("com.xamarinfirebasesample.example", PackageInfoFlags.MetaData));

            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIndtent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var defultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
            var notificationBuilder = new NotificationCompat.Builder(this)
            .SetContentTitle(appName)
            .SetContentText(body)
            .SetSmallIcon(Resource.Drawable.Info)
            .SetAutoCancel(true)
            .SetSound(defultSoundUri)
            .SetContentIntent(pendingIndtent);

            var notificationManger = NotificationManager.FromContext(this);
            notificationManger.Notify(0, notificationBuilder.Build());
        }
    }
}