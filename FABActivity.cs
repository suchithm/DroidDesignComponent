using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using toolbar=Android.Support.V7.Widget.Toolbar;

namespace DesignComponent
{ 
	[Activity (Label = "FAB",MainLauncher=true)]			
	public class FABActivity : AppCompatActivity
	{

		FloatingActionButton fab;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.FABLayout);
			fab =  FindViewById<FloatingActionButton>(Resource.Id.fab); 
			//Floating action button
			fab.Click += (sender, args) =>
			Toast.MakeText (this, GetString (Resource.String.fab_clicked), ToastLength.Short).Show (); 
 
			//set tool bar title
			toolbar toolbar = FindViewById<toolbar> (Resource.Id.app_bar);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetTitle (Resource.String.FAB);

			//bind listview
			var lstViewCityList = FindViewById<ListView> (Resource.Id.lstViewCityList);
			var cityList = new string[]{"Bangalore","Mumbai","Delhi","Hyderbad","Chennai","Gurgaon","Pune","Kalkotta","Mysore","Mangalore","Puttur","Vijaynagar","Bhandra" };
			var arraAdapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleDropDownItem1Line, cityList);
			lstViewCityList.Adapter = arraAdapter;
			lstViewCityList.ChoiceMode=ChoiceMode.Multiple;
			lstViewCityList.CacheColorHint = Android.Graphics.Color.ParseColor("#ff0e135c"); 

		}

		protected override void OnResume ()
		{ 

			
			base.OnResume ();
		}

	}
}

