// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using MailKit.Net.Imap;

Console.WriteLine("Hello, World!");

async Task ConnectAsync()
{
    using var c = new ImapClient();
    await c.ConnectAsync("greenmail", 3143, false);
}

await ConnectAsync(); // this works
Console.WriteLine("Connected to greenmail");

var s = new ActivitySource("demo");
s.StartActivity("test");
Console.WriteLine("Activity started");

await ConnectAsync(); // this doesn't
Console.WriteLine("Connected to greenmail");