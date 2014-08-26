using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Xml;

namespace DataMakerCommonLib
{
	public class DataMakerLib : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName){
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}
		#endregion

		public DataMakerLib() {
		}

		public async Task Start() {
			string[] urls = new string[] {
				"http://www.linkage-club.co.jp/ExamInfo&Data/nyushitango/nyushiA.htm",
				"http://www.linkage-club.co.jp/ExamInfo&Data/nyushitango/nyushiB.htm",
				"http://www.linkage-club.co.jp/ExamInfo&Data/nyushitango/nyushiC.htm",
			};

			try {
				foreach (string url in urls) {
					HttpClient client = new HttpClient ();
					HttpResponseMessage res = await client.GetAsync (url);
					using(XmlReader xml = new XmlReader(await res.Content.ReadAsStreamAsync())){
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex);
			}
		}
	}
}

