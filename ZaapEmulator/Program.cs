using Thrift;
using ZaapProtocol;
using Thrift.Protocol;
using Thrift.Transport.Server;
using Microsoft.Extensions.Logging;
using Thrift.Processor;
using Thrift.Server;
using Thrift.Transport;
using System.Diagnostics;

using var loggerFactory = LoggerFactory.Create(builder => builder.AddSimpleConsole(
    options => { options.IncludeScopes = true;  options.SingleLine = true;
        options.TimestampFormat = "HH:mm:ss "; }));

var transport = new TServerSocketTransport(3001, new TConfiguration());
var trFactory = new TBufferedTransport.Factory();
var proto = new TBinaryProtocol.Factory();

var processor = new ZaapConnectionService.AsyncProcessor(new ConnectHandler(), 
    loggerFactory.CreateLogger<ZaapConnectionService.AsyncProcessor>());

var server = new TSimpleAsyncServer(new TSingletonProcessorFactory(processor), 
    transport, trFactory, trFactory, proto, proto, loggerFactory);


server.SetEventHandler(new ZaapServerEventHandler(loggerFactory));
await Task.WhenAll(
    server.ServeAsync(CancellationToken.None), 
    StartDofus(1));

Console.ReadLine();

static Task StartDofus(int instanceId)
{
    var processDesc = new ProcessStartInfo(@"C:\Users\User\AppData\Local\Ankama\Dofus\Dofus.exe",
    string.Format("--port={0} --gameName=dofus --gameRelease=main --instanceId={1} --hash=a61d76a2-d2a2-44a7-bd13-869cbdbc8613 --canLogin=true", 3001, instanceId));

    var process = new Process() { StartInfo = processDesc };
    process.Start();

    return Task.CompletedTask;
}
class ConnectHandler : ZaapConnectionService.IAsync
{
    public Task<connect_result> connect(connect_args request, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Hello Nameless ! You requested connect with : " + request.ToString());
        return Task.FromResult(new connect_result
        {
            Error = new ZaapError
            {
                Code = 0,
                Details = "Hmmmm..."
            }
        });
    }
}

class ZaapServerEventHandler : TServerEventHandler
{
    public ZaapServerEventHandler(ILoggerFactory f) => _logger = f.CreateLogger<ZaapServerEventHandler>();
    private readonly ILogger _logger;

    public Task PreServeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to serve at 127.0.0.1:3001...");
        return Task.CompletedTask;
    }

    public Task<object?> CreateContextAsync(TProtocol input, TProtocol output, CancellationToken cancellationToken)
    {
        _logger.LogInformation("We got a new customer ! :)");
        return Task.FromResult<object?>(null);
    }

    public Task DeleteContextAsync(object serverContext, TProtocol input, TProtocol output, CancellationToken cancellationToken)
    {
        _logger.LogInformation("We lost a customer ! :(");
        return Task.CompletedTask;
    }

    public Task ProcessContextAsync(object serverContext, TTransport transport, CancellationToken cancellationToken)
    {
        _logger.LogInformation("A customer is attempting to consume our product ! :o");
        return Task.CompletedTask;
    }
}
/*var transport = new TSocketTransport(IPAddress.Loopback, 3001, new TConfiguration());
var protocol = new TBinaryProtocol(transport);

var client = new ZaapConnectionService.Client(protocol);

try
{
    await client.OpenTransportAsync();
}
catch(TApplicationException e)
{
    Console.WriteLine(e);
}
finally
{
    transport.Close();
}*/