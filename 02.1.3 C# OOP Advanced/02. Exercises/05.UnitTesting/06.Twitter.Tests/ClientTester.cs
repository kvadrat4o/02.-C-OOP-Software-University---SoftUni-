using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

[TestFixture]
public class ClientTester
{
    private const string Message = "Test";

    [Test]
    public void CheckIfSendTweetToServerSendsTheMessage()
    {
        var writer = new Mock<IWriter>();
        var tweetRepo = new Mock<ITweetRepository>();
        tweetRepo.Setup(tr => tr.SaveTweet(It.IsAny<string>()));
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);

        microwaveOven.SendTweetToServer(Message);

        tweetRepo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == Message)),
            Times.Once,
            "Message is not sent to the server");
    }

    [Test]
    public void CheckIfWriteTweetWritesTheTweetsMessage()
    {
        var writer = new Mock<IWriter>();
        writer.Setup(w => w.WriteInputOnANewLine(It.IsAny<string>()));
        var tweetRepo = new Mock<ITweetRepository>();
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);

        microwaveOven.WriteTweet(Message);

        writer.Verify(w => w.WriteInputOnANewLine(It.Is<string>(s => s == Message)),
            $"Tweet is not given to the {typeof(MicrowaveOven)}'s writer");
    }
}