namespace MovieManager.Application.Directors.Commands.CreateDirector;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Career)
            .MaximumLength(300);

        RuleFor(x => x.CityOfBirth)
            .MaximumLength(150);

        RuleFor(x => x.CountryOfBirth)
            .MaximumLength(100);

        RuleFor(x => x.Education)
            .MaximumLength(250);
    }
}