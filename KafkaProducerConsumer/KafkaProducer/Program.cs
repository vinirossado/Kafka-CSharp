
using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();
Timer timer;
int i = 1;

try
{
    timer = new Timer(Te2ste, null, TimeSpan.Zero, TimeSpan.FromSeconds(.001));
    while (true)
    {

    }
}
catch (ProduceException<Null, string> ex)
{
    throw ex;
}

void Te2ste(object? state)
{
    string? response = "NY";
    try
    {
        producer.ProduceAsync("weather-topic",
          new Message<Null, string>
          {
              Value = JsonConvert.SerializeObject(
              new Weather(response, i))
          });

        Console.WriteLine($"{response} + {i}");
        i++;

    }
    catch (Exception ex)
    {

        throw new Exception(ex.Message);
    }

    //Console.WriteLine("AgoraVai");

}

public record Weather(string state, int Temperature);

