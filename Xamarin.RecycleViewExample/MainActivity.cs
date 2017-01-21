using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.Widget;
using System;

namespace Xamarin.RecycleViewExample
{
	[Activity(Label = "Xamarin.RecycleViewExample", MainLauncher = true, Icon = "@drawable/icon",Theme="@style/MyTheme")]
	public class MainActivity : AppCompatActivity
	{
		RecyclerView RecView;
		RecyclerView.LayoutManager RecManager;
		RecyclerViewAdapter RecAdapter;
		PhotoAlbums Albums;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Toolbar ToolBar = FindViewById<Toolbar>(Resource.Id.EditToolBar);

			SetSupportActionBar(ToolBar);
			SupportActionBar.Title = "RecyclerView Demo";

			RecView = FindViewById<RecyclerView>(Resource.Id.RecView);

			RecManager = new LinearLayoutManager(this);
			RecView.SetLayoutManager(RecManager);

			Albums = new PhotoAlbums();

			RecAdapter = new RecyclerViewAdapter(Albums);
			RecAdapter.ItemClick += OnItemClick;

			RecView.SetAdapter(RecAdapter);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.top_menus,menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.menu_edit:
					RecManager = new GridLayoutManager(this, 2); //,GridLayoutManager.Vertical,false);
					RecView.SetLayoutManager(RecManager);
					return true;
				case Resource.Id.menu_save:
					if (Albums != null)
					{
						Albums.RandomSwap();
						//RecAdapter.NotifyItemChanged(0);
						//RecAdapter.NotifyItemChanged(Swapped);
						RecAdapter.NotifyDataSetChanged();
					}
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
			//Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();
		}

		void OnItemClick(object sender, int position)
		{
			int photoNum = position + 1;
			Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
		}


	}


}

