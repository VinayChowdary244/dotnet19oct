namespace BusTicketingWebApplication.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Cost { get; set; }
        public int Capacity { get; set; }
        public string Start { get; set; }
        public string End { get; set; }


        public Bus()
        {
            Id = 0;
            Capacity = 0;
        }
        public Bus(int id, string type, float cost, int capacity, string start, string end)
        {
            Id = id;
            Type = type;
            Cost = cost;
            Capacity = capacity;
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"Bus Id : {Id}\n ;Bus Type :{Type}\nBus Capacity{Capacity}\nBus Fare :{Cost}\nBus Starting Location :{Start}\nBus End Location :";
        }
    }
}
