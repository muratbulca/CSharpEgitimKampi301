using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
	public partial class FrmStatistics : Form
	{
		public FrmStatistics()
		{
			InitializeComponent();
		}
		EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
		private void FrmStatistics_Load(object sender, EventArgs e)
		{
			#region Toplam Lokasyon Sayısı
			lblLacationCount.Text= db.Location.Count().ToString();

			#endregion

			#region Toplam Kapasite

			lblSumCapacity.Text = db.Location.Sum(x=>x.Capacity).ToString();
			#endregion

			#region Rehber Sayısı
			lblGuideCount.Text= db.Guide.Count().ToString();
			#endregion

			#region Ortalama Kapasite

			lblAvgCapacity.Text = db.Location.Average(x=>x.Capacity).ToString();
			#endregion

			#region Ortalama Tur Fiyatı

			lblAvgLocationPrice.Text = (Math.Round((double)db.Location.Average(x => x.Price), 2)).ToString("F2") + " ₺";
			#endregion

			#region Eklenen Son Ülke

			int lastcountryId = db.Location.Max(x => x.LocationId);
			lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastcountryId).Select(y => y.Country).FirstOrDefault();
			#endregion

			#region Kapadokya Tur Kapasitesi

			lblCappadociaLocationCapaticy.Text = db.Location.Where(x=>x.City =="Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();

			#endregion

			#region Türkiye Turları Ortalama Kapasite

			lblAvgCapaticyTurkiye.Text = db.Location.Where(x=>x.Country == "Türkiye").Average(y=>y.Capacity).ToString();
			#endregion

			#region Roma Gezi Rehberi

			var romeGuideId = db.Location.Where(x=>x.City == "Roma").Select(y=>y.GuideId).FirstOrDefault();
			lblRomeGuideName.Text = db.Guide.Where(x=>x.GuideId == romeGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
			#endregion

			#region En Yüksek Kapasiteli Tur

			var maxCapacity = db.Location.Max(x=>x.Capacity);
			lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Capacity == maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
			#endregion

			#region En Pahalı Tur

			var maxPrice = db.Location.Max(x=>x.Price);
			lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();
			#endregion

			#region Zeynep Gümüş Tur Sayısı

			var guideIdByNameZeynep = db.Guide.Where(x => x.GuideName == "Zeynep" && x.GuideSurname == "Gümüş").Select(y => y.GuideId).FirstOrDefault();
			lblZeynepLocationCount.Text = db.Location.Where(x=>x.GuideId == guideIdByNameZeynep).Count().ToString();
			#endregion
		}
	}
}
