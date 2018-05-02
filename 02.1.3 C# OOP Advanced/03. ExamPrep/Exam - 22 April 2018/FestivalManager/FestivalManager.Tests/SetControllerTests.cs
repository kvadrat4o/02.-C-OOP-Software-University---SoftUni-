// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
	using NUnit.Framework;
    using System;

	[TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.stage.AddSet("ksjdre", "kjerhweor");
        }

		[Test]
	    public void CheckOutput()
	    {
            
        }

        [Test]
        public void CheckIfCtorSetsStageCorrectly()
        {
            IStage newStage = new Stage();
            Assert.Throws<InvalidOperationException>(() => SetController sct = new SetController(), "Ctor must accept at least one param!");
        }
	}
}