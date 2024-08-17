namespace Words.Tests;

[SetUpFixture]
public class Setup
{
    [OneTimeSetUp]
    public void Initialize() => LoadDictionaries();
}