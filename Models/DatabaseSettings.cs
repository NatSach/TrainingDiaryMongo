namespace TrainigDiaryMongo.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TrainingCollectionName { get; set; }
        public string EventTypeCollectionName { get; set; }
    }
}
