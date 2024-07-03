// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using MailKit.Net.Imap;
using OpenTelemetry;
using OpenTelemetry.Trace;

async Task ConnectAsync()
{
    using var c = new ImapClient();
    await c.ConnectAsync("greenmail", 3143, false);
}

await ConnectAsync(); // this works
Console.WriteLine("Connected to greenmail");

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("demo")
    .AddSource(MailKit.Telemetry.ImapClient.ActivitySourceName)
    .AddConsoleExporter()
    .Build();

var s = new ActivitySource("demo");
s.StartActivity("test");
Console.WriteLine("Activity started");

await ConnectAsync(); // this doesn't
Console.WriteLine("Connected to greenmail");