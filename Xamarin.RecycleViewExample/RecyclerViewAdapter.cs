using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Xamarin.RecycleViewExample
{
	public class RecyclerViewAdapter : RecyclerView.Adapter
	{
		//underlying data(Osnovnaia data)
		public PhotoAlbums PhotoAlbumsData;

		public event EventHandler<int> ItemClick;

		public RecyclerViewAdapter(PhotoAlbums PhotoAlbumsData) 
		{
			this.PhotoAlbumsData = PhotoAlbumsData;
		}

		public override int ItemCount
		{
			get
			{
				return PhotoAlbumsData.NumPhotos;
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var ViewHolder = holder as PhotoAlbumViewHolder;

			ViewHolder.Img.SetImageResource(PhotoAlbumsData[position].PhotoID);
			ViewHolder.Txt.Text = PhotoAlbumsData[position].Caption;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var View = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);

			//PhotoAlbumViewHolder ViewHolder = new PhotoAlbumViewHolder(View);

			return new PhotoAlbumViewHolder(View,OnClick);
		}

		void OnClick(int position)
		{
			if (ItemClick != null)
				ItemClick(this, position);
		}
	}


	class PhotoAlbumViewHolder : RecyclerView.ViewHolder
	{
		public TextView Txt { get; set; }
		public ImageView Img { get; set; }

		public PhotoAlbumViewHolder(View ItemView,Action<int> ItemClicked) : base(ItemView)
		{
			Txt = ItemView.FindViewById<TextView>(Resource.Id.Txt);
			Img = ItemView.FindViewById<ImageView>(Resource.Id.Img);

			ItemView.Click += (sender, e) => ItemClicked(base.Position);
		}
	}



}
