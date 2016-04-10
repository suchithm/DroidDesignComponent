using Android.App;
using Android.Widget;
using Android.OS;
using Android .Support.V4;
using Android.Support.Design;
using Android.Support.Design.Widget; 
using System;


namespace DesignComponent
{
	[Activity (Label = "DesignComponent",  Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{ 
		RelativeLayout linearLayoutMain;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
 			SetContentView (Resource.Layout.Main);
 
			var button = FindViewById<Button> (Resource.Id.btnSimple);
			var btnCallback = FindViewById<Button> (Resource.Id.btnCallback); 
			linearLayoutMain = FindViewById<RelativeLayout> (Resource.Id.linearLayoutMain);

			button.Click += delegate {
				fnSnackBar();
 			};  

			btnCallback.Click += delegate(object sender, EventArgs e) {
				if (!ConnectivityClass.isConnected (this))
					fnSnackBar(GetString (Resource.String.no_internet),true);
				else
					fnSnackBar(GetString (Resource.String.connected_internet),false);
			};
			 

		}
		#region " Snack bar region"
		void fnSnackBar()
		{  
			Snackbar.Make (linearLayoutMain,GetString(Resource.String.deleted),Snackbar.LengthShort)
				.SetAction (Resource.String.undo, (v) => {  
			}) 
				.Show ();
		}
		//customized snackbar
		void fnSnackBar( string strText,bool isNoConnection)
		{ 
			Snackbar objSnackBar = Snackbar.Make (linearLayoutMain, strText, isNoConnection ? Snackbar.LengthIndefinite : Snackbar.LengthShort)
				.SetAction (isNoConnection ? Resource.String.retry : Resource.String.ok , (v) => {
				if (!ConnectivityClass.isConnected (this)) {
					fnSnackBar (GetString (Resource.String.no_internet), true);
				} 
			}); 
			
			//set  action button text color 
			objSnackBar.SetActionTextColor(Android.Graphics.Color.Aqua); 
	
			Android.Views.View objView = objSnackBar.View; 
			TextView txtAction = objView.FindViewById<TextView> (Resource.Id.snackbar_action);
			txtAction.SetTextSize (Android.Util.ComplexUnitType.Dip, 18);
			txtAction.SetTextColor (Android.Graphics.Color.Orange);

			//set message text color
			TextView txtMessage = objView.FindViewById<TextView> (Resource.Id.snackbar_text);
			txtMessage.SetTextColor (Android.Graphics.Color.White);
			txtMessage.SetTextSize (Android.Util.ComplexUnitType.Dip, 18);
     		objSnackBar.Show ();
		}
		#endregion


	}
}


