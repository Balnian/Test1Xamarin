using System;
using System.Collections;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Nfc;
using Android.Net.Wifi;
using Java.Lang;
using System.Collections.Generic;

namespace Test1
{
    [Activity(Label = "Test1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText Login = FindViewById<EditText>(Resource.Id.TB_Username);
            EditText Pass = FindViewById<EditText>(Resource.Id.TB_Password);

            TextView Status = FindViewById<TextView>(Resource.Id.LB_Status);


            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.BT_Login);
            
            




            button.Click += delegate
            {
                WifiManager mngr = (WifiManager)BaseContext.GetSystemService(WifiService);
                mngr.StartScan();
                var SResult = mngr.ScanResults;
                if(SResult.Count > 0)
                {
                    Status.Text = "";
                    foreach (var item in SResult)
                    {
                        if(!String.IsNullOrWhiteSpace(item.Ssid))
                        Status.Text +=  item.Ssid + "("+item.Bssid+")"+" : "+WifiManager.CalculateSignalLevel(item.Level,100)+"/100" + "\n\r"; 
                    }
                    
                }
                //CalculateSignalLevel(ScanResult)

                //if (Login.Text == "Balnian" && Pass.Text == "123")
                //{
                //    Status.Text += "Sucess \n\r"; 
                //}
                //else
                //{
                //    Status.Text += "Login Failed \n\r";
                //}
            };
        }
        class Scanner : AsyncTask<WifiManager, System.Collections.Generic.IList<ScanResult>, Java.Lang.Void>
        {

            protected override Java.Lang.Void RunInBackground(params WifiManager[] @params)
            {
                WifiManager mngr = @params.);
                mngr.StartScan();
                var SResult = mngr.ScanResults;
                if (SResult.Count > 0)
                {
                    Status.Text = "";
                    foreach (var item in SResult)
                    {
                        if (!String.IsNullOrWhiteSpace(item.Ssid))
                            Status.Text += item.Ssid + "(" + item.Bssid + ")" + " : " + WifiManager.CalculateSignalLevel(item.Level, 100) + "/100" + "\n\r";
                    }

                }
            }

            protected override void OnProgressUpdate(params IList<ScanResult>[] values)
            {
                base.OnProgressUpdate(values);
            }

            protected override Java.Lang.Void RunInBackground(params WifiManager[] @params)
            {
                throw new NotImplementedException();
            }
        }

    }
    
}

