using Bogus.Extensions.Brazil;

namespace Todo.Service.UnitTest._Builders.Entities;

public class CompanyBuilder : BaseComplexDbEntityBuilder<CompanyBuilder, Company>
{
    private bool Active;
    private string Cnpj;
    private string FiscalEstablishmentId;

    public static new CompanyBuilder New()
    {
        var faker = new Faker();

        return new CompanyBuilder()
        {
            Active = true,
            Cnpj = faker.Company.Cnpj(false),
            FiscalEstablishmentId = faker.Lorem.Word(),
        };
    }

    protected override CompanyBuilder GetThis()
    {
        return this;
    }

    public CompanyBuilder WithActive(bool value)
    {
        Active = value;
        return this;
    }

    public CompanyBuilder WithCnpj(string value)
    {
        Cnpj = value;
        return this;
    }

    public CompanyBuilder WithFiscalEstablishmentId(string value)
    {
        FiscalEstablishmentId = value;
        return this;
    }

    public override Company Build()
    {
        var model = new Company()
        {
            Active = Active,
            Cnpj = Cnpj,
            FiscalEstablishmentId = FiscalEstablishmentId
        };

        return base.Build(model);
    }
}
