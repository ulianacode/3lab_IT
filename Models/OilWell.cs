namespace OilExtractionApp.Models
{
    public class OilWell
    {
        public string Name { get; set; }
        public double CurrentProduction { get; set; }
        public double TotalExtracted { get; set; }
        public bool IsActive { get; set; }
    }
}