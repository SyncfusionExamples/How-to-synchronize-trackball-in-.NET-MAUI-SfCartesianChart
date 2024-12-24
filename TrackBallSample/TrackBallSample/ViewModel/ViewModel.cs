using System.Collections.ObjectModel;
using TrackBallSample.Model;

namespace TrackBallSample.ViewModel
{
    public class ViewModel
    {
        public int DataCount = 25;
        private readonly Random randomNumber;
        public ObservableCollection<DataModel> DataCollection1 { get; set; }
        public ObservableCollection<DataModel> DataCollection2 { get; set; }
        public ObservableCollection<DataModel> DataCollection3 { get; set; }

        public ViewModel()
        {
            randomNumber = new Random();
            DataCollection1 = GenerateData();
            DataCollection2 = GenerateData();
            DataCollection3 = GenerateData();

        }

        public ObservableCollection<DataModel> GenerateData()
        {
            ObservableCollection<DataModel> datas = new ObservableCollection<DataModel>();
            DateTime date = new DateTime(2020, 1, 1);
            double value = 100;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new DataModel(date, Math.Round(value, 2)));
                date = date.Add(TimeSpan.FromDays(1));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }

}
