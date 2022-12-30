namespace MovieManager.UnitTests.Mapping;

public class MappingTest : IClassFixture<MappingTestFixture>
{
    private readonly IConfigurationProvider _configurationProvider;
    private readonly IMapper _mapper;

    public MappingTest(MappingTestFixture mappingTestFixture)
    {
        _configurationProvider = mappingTestFixture.ConfigurationProvider;
        _mapper = mappingTestFixture.Mapper;
    }

    [Fact]
    public void should_have_valid_configuration()
    {
        _configurationProvider.AssertConfigurationIsValid();
    }

}