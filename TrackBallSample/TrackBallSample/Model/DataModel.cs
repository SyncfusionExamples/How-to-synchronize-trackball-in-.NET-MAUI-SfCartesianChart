
namespace TrackBallSample.Model
{
    public class DataModel(DateTime date, double value)
    {
        public DateTime Date { get; set; } = date;
        public double Value { get; set; } = value;
    }
}
