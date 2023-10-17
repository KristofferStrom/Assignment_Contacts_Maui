namespace Assignment_Contacts_Maui_Tests.UnitTests;

public class FileService_UnitTests
{
    private readonly string _fakePath = $@"c:\{Guid.NewGuid()}\fakefile.txt";

    [Fact]
    public void ReadFromFile_Should_ReturnNull_WhenFileNotExists()
    {
        //Arrange
        IFileService fileService = new FileService();

        //Act
        var result = fileService.ReadFromFile(_fakePath);

        //Assert
        Assert.Null(result);
    }

}
