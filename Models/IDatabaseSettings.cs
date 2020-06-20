namespace TrainigDiaryMongo.Models
{
    public interface IDatabaseSettings
    {
        string TrainingCollectionName { get; set; }
        string EventTypeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
