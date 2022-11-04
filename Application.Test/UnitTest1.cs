namespace Application.Test;

public class UnitTest1
{
    [Fact]
    public void SampleTest()
    {
        //expected
        var expected = 1;
        
        //actual

        var actual = 1;
        
        //assert
        Assert.Equal(expected, actual);
    }
}