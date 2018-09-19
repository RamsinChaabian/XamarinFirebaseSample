using Android.App;
using Android.OS;
using System;
using System.Threading.Tasks;
using Firebase.Iid;

namespace XamarinFirebaseSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            if (!GetString(Resource.String.app_id).Equals("1:1091840819374:android:8b1aef7d7fb311cf"))
                throw new Exception("Invalid Json file");

            Task.Run(() =>
            {
                var instanceId = FirebaseInstanceId.Instance;
                instanceId.DeleteInstanceId();
                Android.Util.Log.Debug("TAG", "{0} {1}", instanceId.Token, instanceId.GetToken(GetString(Resource.String.app_id), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));
            });
        }
    }
}