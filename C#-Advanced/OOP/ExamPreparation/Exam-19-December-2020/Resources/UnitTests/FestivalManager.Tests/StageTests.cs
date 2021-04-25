// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 


namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }


		[Test]
	    public void ConstructorShouldWorksCorrectly()
		{ 
			Assert.IsNotNull(stage);
			Assert.IsNotNull(stage.Performers);
		}

		[Test]
		public void AddPerformerShouldThrowExceptionWithNullValue()
        {
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddPerformer(performer);

			}, "Can not be null!", performer);
        }

		[Test]
		public void AddPerformerShouldThrowExceptionWithPerformerUnder_18()
		{
			Performer performer = new Performer("Pesho", "Peshov", 17);

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddPerformer(performer);

			}, "You can only add performers that are at least 18.");
		}

		[Test]
		public void AddPerformerShouldIncreasePerformersCount()
		{
			Performer performer = new Performer("Pesho", "Peshov", 19);

			this.stage.AddPerformer(performer);	

			Assert.AreEqual(1, this.stage.Performers.Count);
		}

		[Test]
		public void AddSongShouldThrowExceptionWithNullValue()
		{
			Song song = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddSong(song);

			}, "Can not be null!", song);
		}

		[Test]
		public void AddSongShouldThrowExceptionWithTooShortSong()
		{
			Song song = new Song("test", new TimeSpan(0, 0, 50));

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSong(song);

			}, "You can only add songs that are longer than 1 minute.");
		}



		[Test]
		public void AddSongToPerformerShouldThrowExceptionWithNonExistingPerformer()
		{
			Performer performer = new Performer("Pesho","Peshov", 20);
			Song song = new Song("test", new TimeSpan(0, 3, 50));

			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSongToPerformer("test", "gosho");

			}, "There is no performer with this name.");
		}

		[Test]
		public void AddSongToPerformerShouldThrowExceptionWithNullWithNonExistingSong()
		{
			Performer performer = new Performer("Pesho", "Peshov", 20);
			Song song = new Song("test", new TimeSpan(0, 3, 50));

			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSongToPerformer("Pesho Peshov", "ttttt");

			}, "There is no song with this name.");
		}

		[Test]
		public void AddSongToPerformerShouldWorksCorrectly()
		{
			Performer performer = new Performer("Pesho", "Peshov", 20);
			Song song = new Song("test", new TimeSpan(0, 3, 50));

			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);

			this.stage.AddSongToPerformer("test", "Pesho Peshov");

			string expOutput = $"{song} will be performed by {performer}";

			Assert.AreEqual(1, performer.SongList.Count);
		}

		[Test]
		public void AddSongToPerformerShouldReturnCorrectString()
		{
			Performer performer = new Performer("Pesho", "Peshov", 20);
			Song song = new Song("test", new TimeSpan(0, 3, 50));

			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);

			string expOutput = $"{song} will be performed by {performer}";

			Assert.AreEqual(expOutput, this.stage.AddSongToPerformer("test", "Pesho Peshov"));
		}

		[Test]
		public void PlayShouldReturnCorrectString()
        {
			Performer performer = new Performer("Pesho", "Peshov", 20);
			Song song = new Song("test", new TimeSpan(0, 3, 50));
			Performer performer2 = new Performer("Gosho", "Goshov", 30);
			Song song2 = new Song("testtest", new TimeSpan(0, 3, 10));

			this.stage.AddPerformer(performer);
			this.stage.AddPerformer(performer2);
			this.stage.AddSong(song);
			this.stage.AddSong(song2);

			this.stage.AddSongToPerformer("test", "Pesho Peshov");
			this.stage.AddSongToPerformer("testtest", "Gosho Goshov");

			string expOutput = $"{2} performers played {2} songs";

			Assert.AreEqual(expOutput, this.stage.Play());
		}
	}
}