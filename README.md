

# Codeizi.Producer.Kafka

![GitHub](https://img.shields.io/badge/Codeizi-Framework-blueviolet)
![GitHub](https://img.shields.io/github/license/JDouglasMendes/codeizi-producer-kafka)
![publish to nuget](https://github.com/JDouglasMendes/codeizi-producer-kafka/workflows/publish%20to%20nuget/badge.svg?branch=master)

### Instalação

`Install-Package Codeizi.Producer.Kafka`

### Configuração

Na classe `Startup` no método `ConfigureServices` adicionar o código:

````
    services.AddProducerKafka("ServerName:Port");
````

Onde 'ServerName:Port' pode ser o `IP` ou o nome do server que o Kafka está em execução.

### Utilização

Para enviar mensagem utilizar o contrato `IProducerKafka` que é injetado por `Scoped`.

````
    private readonly IProducerKafka producer;

    public ProducerController(IProducerKafka producer)
        => this.producer = producer;
````

Utilizar o método `SendMessage` conforme o exemplo abaixo:

````
    [HttpPost]
    public async Task<IActionResult> PostAsync(string message)
    {
        await producer.SendMessage("Topic_Test", new { Message = message });
        return Ok();
    }
````

