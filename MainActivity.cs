using Android.App;
using Android.Widget;
using Android.OS;
using Android .Support.V4;
using Android.Support.Design;
using Android.Support.Design.Widget; 
using System;


namespace DesignComponent
{
	[Activity (Label = "DesignComponent", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{ 
		LinearLayout linearLayoutMain;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
 			SetContentView (Resource.Layout.Main);
 
			Button button = FindViewById<Button> (Resource.Id.myButton);
			linearLayoutMain = FindViewById<LinearLayout> (Resource.Id.linearLayoutMain);
			button.Click += delegate {
				if (!ConnectivityClass.isConnected (this))
					fnSnackBar(GetString (Resource.String.no_internet),true);
				else
					fnSnackBar(GetString (Resource.String.connected_internet),false);
 			};  
		}
		void fnSnackBar( string strText,bool isLengthIndefinite)
		{
			Snackbar objSnackBar = Snackbar.Make (linearLayoutMain, strText, isLengthIndefinite ? Snackbar.LengthIndefinite : Snackbar.LengthShort)
				.SetAction (Resource.String.retry, (v) => {
				if (!ConnectivityClass.isConnected (this)) {
					fnSnackBar (GetString (Resource.String.no_internet), true);
				}
			}); 
			
			//set  action button text color 
			objSnackBar.SetActionTextColor(Android.Graphics.Color.Aqua); 
	
			Android.Views.View objView = objSnackBar.View; 
			TextView txtAction = objView.FindViewById<TextView> (Resource.Id.snackbar_action);
			txtAction.SetTextSize (Android.Util.ComplexUnitType.Dip, 18);

			//set message text color
			TextView txtMessage = objView.FindViewById<TextView> (Resource.Id.snackbar_text);
			txtMessage.SetTextColor (Android.Graphics.Color.Red);
			txtMessage.SetTextSize (Android.Util.ComplexUnitType.Dip, 18);
     		objSnackBar.Show ();
		}
	}
}


