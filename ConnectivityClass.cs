using System;
using Android.Net;
using Android.Content;

namespace DesignComponent
{
	public static class ConnectivityClass
	{ 
		public static bool isConnected(Context context)
		{
			ConnectivityManager connectivityManager = (ConnectivityManager) context.GetSystemService(Android.Content.Context.ConnectivityService);

			NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
			bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
			return isOnline;
		}
	}
}

