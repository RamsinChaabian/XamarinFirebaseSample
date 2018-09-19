using Android.App;
using Android.Content;
using Firebase.Iid;

namespace XamarinFirebaseSample
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class FirebaseIdService: FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            base.OnTokenRefresh();
            Android.Util.Log.Debug("Refreshed:", FirebaseInstanceId.Instance.Token);
        }
    }
}